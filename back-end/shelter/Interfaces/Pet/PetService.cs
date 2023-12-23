using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using shelter.DataBaseContext.ShelterPetFinderDbContext;
using shelter.Dtos.PetDto;
using shelter.Models.PetModels;
using System.Reflection.Metadata;
using System.Text;

namespace shelter.Interfaces.Pet
{
    public class PetService : IPetService
    {
        private readonly ShelterPetFinderDbContext _shelterPetFinderDbContext;
        private readonly IMapper _mapper;
        private  MemoryStream _imagesStream;
        public PetService
        (
            ShelterPetFinderDbContext shelterPetFinderDbContext,
            IMapper mapper
           

        )
        {
            _shelterPetFinderDbContext = shelterPetFinderDbContext;
            _mapper = mapper;
        }

        public async Task<bool> AddPetForm(PetForm pet)
        {
            try
            {
                var newPetModel = _mapper.Map<PetModel>(pet);

                var shelterId = _shelterPetFinderDbContext.Shelters
                    .Where(shEmail=>shEmail.Email == pet.ShelterEmail)
                    .Select(shId => shId.Id)
                    .FirstOrDefault();

                newPetModel.ShelterModelId = shelterId;
                _shelterPetFinderDbContext.Pets.Add(newPetModel);
                await _shelterPetFinderDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeletePet(int id)
        {
            var petToDelete = await _shelterPetFinderDbContext.Pets.FindAsync(id);
            if (petToDelete == null)
            {
                return false;
            }

            _shelterPetFinderDbContext.Pets.Remove(petToDelete);
            await _shelterPetFinderDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<PetsBelongsToShelterDto>> GetAllPets()
        {
            try
            {
                var allPets = await _shelterPetFinderDbContext.Pets
                    .Include(p => p.Images)
                    .Include(s=>s.ShelterModel)
                    .Where(s=>s.ShelterModel.Id == s.ShelterModelId)
                    .ToListAsync();

                var petsToGet = _mapper.Map<List<PetsBelongsToShelterDto>>(allPets);

                return petsToGet;
            }
            catch (Exception ex) 
            {

                return null;
            }
            
        }

        public async Task<bool> UpdatePet(PetForm pet)
        {
            try
            {
                var newPetModel = _mapper.Map<PetModel>(pet);

                var petToUpdate = _shelterPetFinderDbContext.Pets.FirstOrDefaultAsync(petId=>petId.Id == pet.Id);  
                if (petToUpdate == null) 
                {
                    return false;
                }

               var updatedPet = await _mapper.Map(newPetModel, petToUpdate);
                _shelterPetFinderDbContext.Pets.Update(updatedPet);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
