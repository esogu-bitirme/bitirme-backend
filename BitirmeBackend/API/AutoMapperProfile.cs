using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Modals;
using AutoMapper;
using Entities.Request;
using Entities;
using Entities.Response;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserRequestDto, User>().ReverseMap();
        CreateMap<User, UserResponseDto>().ReverseMap();
        CreateMap<User, UserUpdateRequestDto>().ReverseMap();

        CreateMap<DoctorRequestDto, Doctor>().ReverseMap();
        CreateMap<Doctor, DoctorResponseDto>().ReverseMap();
        CreateMap<Doctor, DoctorUpdateRequestDto>().ReverseMap();
    }
}