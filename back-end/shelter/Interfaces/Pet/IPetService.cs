using shelter.Dtos.PetDto;
using shelter.Models.PetModels;

namespace shelter.Interfaces.Pet
{
    public interface IPetService
    {
        Task<bool> AddPetForm(PetForm pet);
        Task<bool> UpdatePet(PetForm pet);
        Task <bool> DeletePet(int id);
        Task<List<PetsBelongsToShelterDto>> GetAllPets();
        Task<PetByIdDto> GetPetById(int id);
        Task<bool> AddLikedPetList(LikedPetListModel likedPetListModel);
    }
}
