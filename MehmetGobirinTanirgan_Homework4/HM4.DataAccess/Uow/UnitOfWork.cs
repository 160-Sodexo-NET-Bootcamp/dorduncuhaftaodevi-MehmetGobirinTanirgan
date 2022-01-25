using HM4.Core.DataAccess.Repositories;
using HM4.Core.DataAccess.Uow;
using HM4.DataAccess.Context;
using HM4.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM4.DataAccess.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            Users = new UserRepository(dbContext);
            this.dbContext = dbContext;
        }

        public IUserRepository Users { get; private set; }  

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
