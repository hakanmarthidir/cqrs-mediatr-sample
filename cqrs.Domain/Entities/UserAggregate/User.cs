using cqrs.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs.Domain.Entities.UserAggregate
{

    public class User : BaseEntity, IAggregateRoot
    {
        public virtual string Email { get; set; }
        public virtual string FullName { get; set; }


        public static User CreateUser(string email, string fullname)
        {
            return new User() {
             Email = email,
             FullName = fullname,
             Id = Guid.NewGuid()
            };

        }
    }
}
