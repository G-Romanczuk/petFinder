using AutoMapper;
using shelter.Models.UserModels;
using shelter.UserDtos;
using System.Text.Json;

namespace shelter.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserModel, UserRegisterDto>();
            CreateMap<JsonElement, UserModel>();
        }
    }
}
