using shelter.Dtos.PetDtos;
using shelter.Models.PetModels;

namespace shelter.Interfaces.Pet
{
    public interface IPetService
    {
        Task<bool> AddPetForm(PetForm pet);
    }
}
