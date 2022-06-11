using cqrs.Domain.Entities.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrs.Infrastructure.Persistence.Context
{
    public class CqrsDbContext : DbContext
    {
        private readonly IMediator? _mediator;
        public DbSet<Domain.Entities.UserAggregate.User> User { get; set; }
        public string DbPath { get; }

        public CqrsDbContext(IMediator? mediator)
        {
            this._mediator = mediator;
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "cqrs_sample.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_mediator == null) return result;

            await this.DispatchEvents();

            return result;
        }

        private async Task DispatchEvents()
        {
            var entityWithRaisedEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e._domainEvents.Any())
                .ToList();

            foreach (var entity in entityWithRaisedEvents)
            {
                var raisedEvents = entity._domainEvents.ToList();
                entity.ClearEvents();
                foreach (var domainEvent in raisedEvents)
                {
                    await _mediator.Publish(domainEvent).ConfigureAwait(false);
                }

            }
        }
    }
}
