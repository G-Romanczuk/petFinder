using shelter.Models.PetModels;

namespace shelter.Interfaces.Pet
{
    public interface IPetService
    {
        Task<bool> AddPet(PetModel pet);
    }
}
