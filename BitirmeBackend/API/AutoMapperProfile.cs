using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Modals;
using AutoMapper;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserRequestDto, User>().ReverseMap();
        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<User, UserUpdateRequestDto>().ReverseMap();
    }
}