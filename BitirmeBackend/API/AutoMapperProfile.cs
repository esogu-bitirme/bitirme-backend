using Entities.Dtos.Request;
using Entities.Dtos.Response;
using Entities.Dtos;
using Entities.Modals;
using AutoMapper;
using Entities;


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

        CreateMap<PatientRequestDto, Patient>().ReverseMap();
        CreateMap<Patient, PatientResponseDto>().ReverseMap();
        CreateMap<Patient, PatientUpdateRequestDto>().ReverseMap();

        CreateMap<Comment, CommentDto>().ReverseMap();

        CreateMap<ReportResponseDto, Report>().ReverseMap();
        CreateMap<Report, ReportUpdateRequestDto>().ReverseMap();
        CreateMap<Report, ReportRequestDto>().ReverseMap();

        CreateMap<ImageDto, Image>().ReverseMap();
        CreateMap<Image, ImageUpdateRequestDto>().ReverseMap();
    }
}