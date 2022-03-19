using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using MongoDataAccess.DataAccess.Abstract;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess.Concrete
{
    public class MongoChoreRepository : ConnectionToMongo,IMongoRepositoryBase<ChoreModel>
    {
        private readonly IMongoCollection<ChoreModel> _choreCollection;
        
        public MongoChoreRepository()
        {
            _choreCollection = GetConnection<ChoreModel>(ChoreCollection);
        }
        public async Task<List<ChoreModel>> GetAll()
        {
            var chores = await _choreCollection.FindAsync(_ => true);
            return chores.ToList();
        }

        public async Task<ChoreModel> GetById(string choreId)
        {
            var chore = await _choreCollection.FindAsync(c => c.Id == choreId);
            return chore.SingleOrDefault();
        }

        public Task Create(ChoreModel entity)
        {
          return _choreCollection.InsertOneAsync(entity);
        }

        public Task Update(ChoreModel entity)
        {
            var filter = Builders<ChoreModel>.Filter.Eq("Id", entity.Id);
            return _choreCollection.ReplaceOneAsync(filter, entity);
        }

        public Task Delete(ChoreModel entity)
        {
            return _choreCollection.DeleteOneAsync(c=>c.Id == entity.Id);
        }

        public async Task<List<ChoreModel>> GetAllChoresForAUser(UserModel model)
        {
            var results = await _choreCollection.FindAsync(c => c.AssignedTo.Id == model.Id);
            return results.ToList();
        }
    }
}
