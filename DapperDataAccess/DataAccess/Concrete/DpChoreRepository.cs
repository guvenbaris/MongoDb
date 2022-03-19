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
    public class DpChoreRepository : IDapperRepositoryBase<ChoreModel>
    {
        private readonly IDbConnection _dbConnection;

        public DpChoreRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<ChoreModel>> GetAll()
        {
            string sql = $"Select * From {DpTableName.ChoreModel};";
            var chores = await _dbConnection.QueryAsync<ChoreModel>(sql);
            return chores.ToList();
        }

        public async Task<ChoreModel> GetById(string id)
        {
            string sql = $"Select * From {DpTableName.ChoreModel} Where Id = {id};";
            var chores = await _dbConnection.QueryAsync<ChoreModel>(sql);
            return chores.SingleOrDefault();
        }

        public async Task Create(ChoreModel entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            string sql = $"Insert into {DpTableName.ChoreModel} " +
                         $"(Id,ChoreText,FrequencyInDays,AssignedTo) Values" +
                         $" ('{entity.Id}','{entity.ChoreText}',{entity.FrequencyInDays}, '{entity.AssignedTo?.Id}');";


  
            await _dbConnection.ExecuteAsync(sql);
        }

        public Task Update(ChoreModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ChoreModel entity)
        {
            throw new NotImplementedException();
        }
    }

}
