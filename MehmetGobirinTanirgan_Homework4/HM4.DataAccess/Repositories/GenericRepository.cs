using HM4.Core.DataAccess.Repositories;
using HM4.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HM4.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetListByExp(Expression<Func<T, bool>> exp)
        {
            return dbContext.Set<T>().Where(exp);
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            dbContext.Set<T>().UpdateRange(entities);
        }
    }
}
