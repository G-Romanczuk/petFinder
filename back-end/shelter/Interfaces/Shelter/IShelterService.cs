using shelter.Dtos.ShelterDtos;
using shelter.Models.ShelterModels;

namespace shelter.Interfaces.Shelter
{
    public interface IShelterService
    {
        Task<ShelterLoginDto> CreateAccount(string email);
        Task<bool> CreateUserShelter(string email);
        string GenerateTokenString(ShelterLoginDto shelter);
        Task<bool> LoginUser(ShelterLoginDto shelter);
        Task<bool> AddShelterDetailsForm(ShelterForm shelterForm);
    }
}
