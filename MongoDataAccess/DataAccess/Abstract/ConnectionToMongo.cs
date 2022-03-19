using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MongoDataAccess.DataAccess.Abstract
{
    public abstract class ConnectionToMongo : BaseMongoConfiguration
    {
        public IMongoCollection<T> GetConnection<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }
    }
}


