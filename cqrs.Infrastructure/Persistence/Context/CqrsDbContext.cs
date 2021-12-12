using Microsoft.EntityFrameworkCore;

namespace cqrs.Infrastructure.Persistence.Context
{
    public class CqrsDbContext : DbContext
    {
        public DbSet<Domain.Entities.UserAggregate.User> User { get; set; }
        public string DbPath { get; }

        public CqrsDbContext()
        {
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
    }
}
