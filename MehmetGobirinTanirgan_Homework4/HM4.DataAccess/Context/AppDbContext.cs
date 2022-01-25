using HM4.Entities.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HM4.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
