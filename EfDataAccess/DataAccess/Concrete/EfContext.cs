using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfDataAccess.DataAccess.Concrete
{
    public class EfContext :DbContext
    {
        public EfContext(DbContextOptions<EfContext> options) :base(options)
        {
            
        }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<ChoreModel> ChoreModels { get; set; }
    }
}
