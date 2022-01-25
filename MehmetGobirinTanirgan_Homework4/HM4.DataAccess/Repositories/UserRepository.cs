using HM4.Core.DataAccess.Repositories;
using HM4.DataAccess.Context;
using HM4.Entities.DataModels;

namespace HM4.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
