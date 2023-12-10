using AutoMapper;
using shelter.Dtos.UserDtos;
using shelter.Models.PetModels;
using shelter.Models.ShelterModels;
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

            CreateMap<ShelterForm, ShelterModel>();
            CreateMap<Questions, ShelterHabbitsModel>();
            CreateMap<Questions, ShelterResidenceModel>();
            CreateMap<Questions, ShelterPetDetailsModel>();

            CreateMap<ShelterRegisterForm, ShelterModel>();

            CreateMap<PetForm, PetModel>();
            CreateMap<PetModel, PetForm>();
        }
    }
    



}
