using HM4.Core.DataAccess.Repositories;
using System.Threading.Tasks;

namespace HM4.Core.DataAccess.Uow
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task SaveAsync();
    }
}
