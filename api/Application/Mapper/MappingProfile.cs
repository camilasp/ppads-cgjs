using AutoMapper;
using Domain.Entities;
using Domain.Entities.DTO;

namespace Application.Mapper
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
