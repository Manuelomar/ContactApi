using Persons.Application.Common.Interfaces.Repositories;
using Persons.Domain.Base;

namespace Persons.Application.Common.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<bool> Commit();
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
    }
}
