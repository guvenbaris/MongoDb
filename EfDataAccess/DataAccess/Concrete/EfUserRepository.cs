using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using EfDataAccess.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EfDataAccess.DataAccess.Concrete
{
    public class EfUserRepository :IEfRepositoryBase<UserModel>
    {
        private readonly EfContext _context;

        public EfUserRepository(EfContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetAll()
        {
            var users = await _context.UserModels.ToListAsync();
            return users;
        }

        public async Task<UserModel> GetById(string id)
        {
            var user = await _context.UserModels.SingleOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public  List<UserModel> SearchFirstName(string firstName)
        {
            var users = _context.UserModels.Where(u => u.FirstName.Contains("a"));
            return users.ToList();
        }

        public Task Create(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
