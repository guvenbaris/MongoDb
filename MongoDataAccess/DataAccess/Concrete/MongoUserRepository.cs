using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDataAccess.DataAccess.Abstract;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess.Concrete
{
    public class MongoUserRepository : ConnectionToMongo, IMongoRepositoryBase<UserModel>
    {
        private readonly IMongoCollection<UserModel> _userCollection;
        public MongoUserRepository()
        {
            _userCollection = GetConnection<UserModel>(UserCollection);
        }
        
        public async Task<List<UserModel>> GetAll()
        {
            var results = await _userCollection.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<UserModel> GetById(string userId)
        {
            var user = await _userCollection.FindAsync(u => u.Id == userId);
            return user.SingleOrDefault();
        }

        public async Task<List<UserModel>> SearchFirstName(string firstName)
        {
            var users = await _userCollection.FindAsync(u => u.FirstName.Contains("a"));
            return users.ToList();
        }


        public Task Create(UserModel entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            return _userCollection.InsertOneAsync(entity);
        }

        public Task Update(UserModel entity)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", entity.Id);
            return _userCollection.ReplaceOneAsync(filter, entity);
        }

        public Task Delete(UserModel entity)
        {
            return _userCollection.DeleteOneAsync(c => c.Id == entity.Id);
        }
    }
}
