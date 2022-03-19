using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess
{
    public class ChoreDataAccess
    {
        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "choredb";
        private const string ChoreCollection = "chore_chart";
        private const string UserCollection = "users";
        private const string ChoreHistoryCollection = "chore_history";

        private IMongoCollection<T> ConnectionToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var usersCollection = ConnectionToMongo<UserModel>(UserCollection);
            var results = await usersCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<List<ChoreModel>> GetAllChores()
        {
            var choresCollection = ConnectionToMongo<ChoreModel>(ChoreCollection);
            var results = await choresCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<List<ChoreModel>> GetAllChoresForAUser(UserModel user)
        {
            var choresCollection = ConnectionToMongo<ChoreModel>(ChoreCollection);
            var results = await choresCollection.FindAsync(c=>c.AssignedTo.Id == user.Id);
            return results.ToList();
        }

        public Task CreateUser(UserModel user)
        {
            var usersCollection = ConnectionToMongo<UserModel>(UserCollection);
            return usersCollection.InsertOneAsync(user);
        }

        public Task CreateChoreModel(ChoreModel chore)
        {
            var choresCollection = ConnectionToMongo<ChoreModel>(ChoreCollection);
            return choresCollection.InsertOneAsync(chore);
        }

        public Task UpdateChoreModel(ChoreModel chore)
        {
            var choresCollection = ConnectionToMongo<ChoreModel>(ChoreCollection);
            var filter = Builders<ChoreModel>.Filter.Eq("Id", chore.Id);
            return choresCollection.ReplaceOneAsync(filter, chore, new ReplaceOptions {IsUpsert = true});
        }
        
        public Task DeleteChoreModel(ChoreModel chore)
        {
            var choresCollection = ConnectionToMongo<ChoreModel>(ChoreCollection);
            return choresCollection.DeleteOneAsync(c => c.Id == chore.Id);
        }

        public async Task CompleteChore(ChoreModel chore)
        {
            //var choresCollection = ConnectionToMongo<ChoreModel>(ChoreCollection);
            //var filter = Builders<ChoreModel>.Filter.Eq("Id", chore.Id);
            //await choresCollection.ReplaceOneAsync(filter, chore);

            //var choreHistoryCollection = ConnectionToMongo<ChoreHistoryModel>(ChoreHistoryCollection);
            //await choreHistoryCollection.InsertOneAsync(new ChoreHistoryModel(chore));


            // Uygulama çalışırken hata oluşursa birinci kaydetmeyi yapıp ikinci kaydetmeyi
            // yapamadığı takdirde kritik bir işlemse veri kaybı olur(Hesaba para yatırma vb.)

            var client = new MongoClient(ConnectionString);
            using var session = await client.StartSessionAsync();

            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(DatabaseName);
                var choresCollection = db.GetCollection<ChoreModel>(ChoreCollection);
                var filter = Builders<ChoreModel>.Filter.Eq("Id", chore.Id);
                await choresCollection.ReplaceOneAsync(filter, chore);

                var choreHistoryCollection = db.GetCollection<ChoreHistoryModel>(ChoreHistoryCollection);
                await choreHistoryCollection.InsertOneAsync(new ChoreHistoryModel(chore));

                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
