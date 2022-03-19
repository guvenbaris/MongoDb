using System.Collections.Generic;
using System.Threading.Tasks;


namespace MongoDataAccess.DataAccess.Abstract
{
    public interface IMongoRepositoryBase<T>
    {
         Task<List<T>> GetAll();
         Task<T> GetById(string id);
         Task Create(T entity);
         Task Update(T entity);
         Task Delete(T entity);
    }
}



