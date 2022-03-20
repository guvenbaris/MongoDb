using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using EfDataAccess.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EfDataAccess.DataAccess.Concrete
{
    public class EfChoreRepository :IEfRepositoryBase<ChoreModel>
    {
        private readonly EfContext _context;

        public EfChoreRepository(EfContext context)
        {
            _context = context;
        }

        public async Task<List<ChoreModel>> GetAll()
        {
            var choreModels = await _context.ChoreModels.ToListAsync();
            return choreModels;
        }

        public async Task<ChoreModel> GetById(string id)
        {
            var choreModel = await _context.ChoreModels.SingleOrDefaultAsync(u => u.Id == id);
            return choreModel;
        }

        public Task Create(ChoreModel entity)
        {
            throw new NotImplementedException();
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
