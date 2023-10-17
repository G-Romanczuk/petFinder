using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using shelter.DataBaseContext.PetDbContext;
using shelter.Dtos.PetDtos;
using shelter.Models.PetModels;

namespace shelter.Interfaces.Pet
{
    public class PetService : IPetService
    {
        private readonly PetDbContext _petDbContext;
        private readonly IMapper _mapper;
        public PetService
        (
            PetDbContext petDbContext,
            IMapper mapper
        )
        {
            _petDbContext = petDbContext;
            _mapper = mapper;
        }

        public async Task<bool> AddPetForm(PetForm pet)
        {
       
            try
            {
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
