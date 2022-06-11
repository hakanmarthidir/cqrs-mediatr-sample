using cqrs.Domain.Entities.Shared;

namespace cqrs.Domain.Entities.UserAggregate
{
    public class UserCreatedEvent : DomainEvent
    {
        public User CreatedUser { get; }

        public UserCreatedEvent(User user)
        {
            this.CreatedUser = user;
        }
    }
}
