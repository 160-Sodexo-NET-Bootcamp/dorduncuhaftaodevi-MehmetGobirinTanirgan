using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HM4.Core.DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void UpdateRange(List<T> entities);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetListByExp(Expression<Func<T, bool>> exp);
    }
}
