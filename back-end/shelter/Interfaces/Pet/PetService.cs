using AutoMapper;
using shelter.DataBaseContext.PetDbContext;
using shelter.Dtos.PetsDtos;
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
        public async Task<bool> AddPet(PetDto pet)
        {
             var petToAdd = _mapper.Map<PetModel>(pet);

            try
            {
                _petDbContext.Pets.Add(petToAdd);
                await _petDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       
    }
}
