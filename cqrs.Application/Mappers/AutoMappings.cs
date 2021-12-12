using AutoMapper;
using cqrs.Application.User.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrs.Application.Mappers
{
    public class AutoMappings : Profile
    {
        public AutoMappings()
        {
            // FROM Domain -> TO Dto
            CreateMap<Domain.Entities.UserAggregate.User, UserDto>();
            
        }
    }
}
