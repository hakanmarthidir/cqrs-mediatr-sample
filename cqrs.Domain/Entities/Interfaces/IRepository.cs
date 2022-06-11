using cqrs.Domain.Entities.Shared;
using System.Linq.Expressions;

namespace cqrs.Domain.Entities.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        Task<TEntity> FindByIdAsync(Guid id, CancellationToken token = default(CancellationToken));
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? page = null, int? pageSize = null);
        Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? page = null, int? pageSize = null);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter);
        Task InsertAsync(TEntity entity, CancellationToken token = default(CancellationToken));
        Task InsertAllAsync(IEnumerable<TEntity> entities, CancellationToken token = default(CancellationToken));
        Task UpdateAsync(TEntity entity, CancellationToken token = default(CancellationToken));
        Task DeleteAsync(Guid id, CancellationToken token = default(CancellationToken));
    }
}
