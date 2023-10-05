using shelter.Dtos.PetsDtos;
using shelter.Models.PetModels;

namespace shelter.Interfaces.Pet
{
    public interface IPetService
    {
        Task<bool> AddPet(PetDto pet);
    }
}
