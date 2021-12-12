using cqrs.Domain.Entities.Interfaces;

namespace cqrs.Domain.Entities.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    { }
}
