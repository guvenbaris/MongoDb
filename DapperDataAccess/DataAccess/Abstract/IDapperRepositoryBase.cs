using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperDataAccess.DataAccess.Abstract
{
    public interface IDapperRepositoryBase<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
