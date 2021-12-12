using cqrs.Application.Interfaces;
using cqrs.Application.Response;
using cqrs.Domain.Entities.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs.Application.User.Commands
{
    public class CreateUserCommand : IRequest<IServiceResponse>
    {
        public string Email { get; set; }
        public string Name { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IServiceResponse>
        {
            private readonly IUserRepository _userRepository;
            
            public CreateUserCommandHandler(IUserRepository userRepository)
            {
                this._userRepository = userRepository;
            }

            public async Task<IServiceResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var created = Domain.Entities.UserAggregate.User.CreateUser(request.Email, request.Name);
                await this._userRepository.InsertAsync(created).ConfigureAwait(false);
                return ServiceResponse.Success($"{request.Name}'s account was successfully created.");
            }
        }
    }
}
