using AutoMapper;
using shelter.Dtos.PetDto;
using shelter.Dtos.ShelterDtos;
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

            CreateMap<UserModel, UserForm>();
            CreateMap<UserHabbitsModel, UserForm>();
            CreateMap<UserResidenceModel, UserForm>();
            CreateMap<UsersDogDetailsModel, UserForm>();

            CreateMap<ShelterForm, ShelterModel>();
            CreateMap<ShelterForm, ShelterHabbitsModel>();
            CreateMap<ShelterForm, ShelterResidenceModel>();
            CreateMap<ShelterForm, ShelterPetDetailsModel>();

            CreateMap<ShelterModel, ShelterForm>();
            CreateMap<ShelterHabbitsModel, ShelterForm>();
            CreateMap<ShelterResidenceModel, ShelterForm>();
            CreateMap<ShelterPetDetailsModel, ShelterForm>();

            CreateMap<ShelterRegisterForm, ShelterModel>();


            CreateMap<PetForm, PetModel>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(img => new PetImg { Images = img })));

            CreateMap<PetModel, PetsBelongsToShelterDto>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(img => img.Images)))
            .ForMember(dest => dest.shelterModel, opt => opt.MapFrom(src => src.ShelterModel));

            CreateMap<ShelterModel, ShelterModelDto>();
            CreateMap<PetImg, PetsBelongsToShelterDto>();

            CreateMap<PetModel, PetByIdDto>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(img => img.Images)))
            .ForMember(dest => dest.shelterModel, opt => opt.MapFrom(src => src.ShelterModel));

            CreateMap<PetImg, PetByIdDto>();
        }
       
    }
    



}
