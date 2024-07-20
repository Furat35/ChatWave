using AutoMapper;
using ChatWave.Application.Dtos.Users;
using ChatWave.Application.Features.Commands.Users;
using ChatWave.Domain.Entities;

namespace ChatWave.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserListDto>();

            CreateMap<CreateUserCommand, UserCreateDto>();
            CreateMap<UpdateUserCommand, UserUpdateDto>();
        }
    }
}
