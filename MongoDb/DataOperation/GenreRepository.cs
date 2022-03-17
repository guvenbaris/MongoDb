using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDb.Entities;

namespace MongoDb.DataOperation
{
    public class GenreRepository
    {

        public async Task<List<Genre>> GetAll()
        {
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "book_db";
            string collectionName = "genre";

            var client = new MongoClient(connectionString);
            //Db name
            var db = client.GetDatabase(databaseName);
            // Collection Name
            var collection = db.GetCollection<Genre>(collectionName); 

            var genre = new Genre {Name = "Bilim Kurgu"};


            //Add record
            await collection.InsertOneAsync(genre);

            //Find record
            var results = await collection.FindAsync(_ => true);

            return results.ToList();
        }
    }
}
