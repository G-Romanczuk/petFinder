﻿using AutoMapper;
using shelter.Dtos.UserDtos;
using shelter.Models.UserModels;
using System.Text.Json;
using shelter.Models.PetModels;
using shelter.Dtos.PetDtos;

namespace shelter.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PetDto, PetModel>(); // Dodaj mapowanie dla PetDto -> PetModel
            CreateMap<UserModel, UserRegisterDto>();
            CreateMap<UserRegisterDto, UserModel>();
            CreateMap<JsonElement, UserModel>();
            CreateMap<UserModel, UserModel>();
        }
    }
    



}
