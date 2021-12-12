using cqrs.Domain.Entities.Interfaces;
using cqrs.Domain.Entities.Shared;
using cqrs.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cqrs.Infrastructure.Persistence.Context
{
    public class CqrsRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        protected readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbset;

        public CqrsRepository(CqrsDbContext mainContext)
        {
            _dbContext = mainContext ?? throw new ArgumentNullException("Database Context can not be null.");
            _dbset = _dbContext.Set<TEntity>();
        }

        public Task DeleteAsync(Guid id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? page = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? page = null, int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbset;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public Task<TEntity> FindByIdAsync(Guid id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task InsertAllAsync(IEnumerable<TEntity> entities, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(TEntity entity, CancellationToken token = default)
        {
            await this._dbset.AddAsync(entity, token).ConfigureAwait(false);
            await this._dbContext.SaveChangesAsync(token).ConfigureAwait(false);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
