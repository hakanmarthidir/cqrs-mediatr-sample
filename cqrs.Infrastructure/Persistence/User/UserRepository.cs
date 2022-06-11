using cqrs.Domain.Entities.UserAggregate;
using cqrs.Infrastructure.Persistence.Context;

namespace cqrs.Infrastructure.Persistence.User
{
    public class UserRepository : CqrsRepository<Domain.Entities.UserAggregate.User>, IUserRepository
    {
        public UserRepository(CqrsDbContext dbContext) : base(dbContext)
        {

        }
    }
}
