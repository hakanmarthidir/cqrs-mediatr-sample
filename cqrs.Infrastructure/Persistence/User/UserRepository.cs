using cqrs.Domain.Entities.UserAggregate;
using cqrs.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs.Infrastructure.Persistence.User
{
    public class UserRepository : CqrsRepository<Domain.Entities.UserAggregate.User>, IUserRepository
    {
        public UserRepository(CqrsDbContext dbContext) : base(dbContext)
        {

        }
    }
}
