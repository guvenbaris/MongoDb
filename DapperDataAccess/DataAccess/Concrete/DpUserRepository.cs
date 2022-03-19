using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperDataAccess.DataAccess.Abstract;
using Domain.Entities;

namespace DapperDataAccess.DataAccess.Concrete
{
    public class DpUserRepository : IDapperRepositoryBase<UserModel>
    {
        private readonly IDbConnection _dbConnection;

        public DpUserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<UserModel>> GetAll()
        { 
            string sql = $"Select * From UserModels;";
            var users = await _dbConnection.QueryAsync<UserModel>(sql);
            return users.ToList();
        }

        public async Task<UserModel> GetById(string id)
        {
            string sql = $"Select * From UserModels Where Id = {id};";

            return await _dbConnection.QuerySingleOrDefaultAsync<UserModel>(sql);
        }

        public async Task Create(UserModel entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            string sql = $"Insert into UserModels (Id,FirstName,LastName,FullName) Values ('{entity.Id}','{entity.FirstName}','{entity.LastName}','{entity.FullName}');";

            await _dbConnection.ExecuteAsync(sql);
        }

        public Task Update(UserModel entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(UserModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
