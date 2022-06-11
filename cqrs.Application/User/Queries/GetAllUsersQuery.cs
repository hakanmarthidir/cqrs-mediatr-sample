using AutoMapper;
using cqrs.Application.Response;
using cqrs.Application.User.Dtos;
using cqrs.Domain.Entities.UserAggregate;
using MediatR;

namespace cqrs.Application.User.Queries
{
    public class GetAllUsersQuery : IRequest<IServiceResponse<List<UserDto>>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IServiceResponse<List<UserDto>>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                this._userRepository = userRepository;
                this._mapper = mapper;
            }


            public async Task<IServiceResponse<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var result = await this._userRepository.FindAsync().ConfigureAwait(false);
                var userList = _mapper.Map<List<UserDto>>(result);
                return ServiceResponse<List<UserDto>>.Success(userList);

            }
        }
    }
}
