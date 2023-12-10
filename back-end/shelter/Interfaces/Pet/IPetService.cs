using shelter.Models.PetModels;

namespace shelter.Interfaces.Pet
{
    public interface IPetService
    {
        Task<bool> AddPetForm(PetForm pet);
        Task<bool> UpdatePet(PetForm pet);
        Task <List<PetModel>> GetAllPets();
    }
}
