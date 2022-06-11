using cqrs.Domain.Entities.Shared;

namespace cqrs.Domain.Entities.UserAggregate
{

    public class User : BaseEntity, IAggregateRoot
    {
        public virtual string Email { get; set; }
        public virtual string FullName { get; set; }

        public User()
        {
        }

        private User(string email, string fullname) : this()
        {
            Id = Guid.NewGuid();
            Email = email;
            FullName = fullname;
            this.RaiseEvent(new UserCreatedEvent(this));
        }

        public static User CreateUser(string email, string fullname)
        {
            return new User(email, fullname);
        }
    }
}
