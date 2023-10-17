using AutoMapper;
using shelter.Dtos.UserDtos;
using shelter.Models.UserModels;
using System.Text.Json;

namespace shelter.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, UserRegisterDto>();
            CreateMap<UserRegisterDto, UserModel>();
            CreateMap<JsonElement, UserModel>();
            CreateMap<UserModel, UserModel>();

            CreateMap<UserForm, UserModel>();
            CreateMap<UserForm, UserHabbitsModel>();
            CreateMap<UserForm, UserResidenceModel>();
            CreateMap<UserForm, UsersDogDetailsModel>();
        }
    }
    



}
