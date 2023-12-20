using shelter.Dtos.PetDto;
using shelter.Dtos.ShelterDtos;
using shelter.Models.PetModels;
using shelter.Models.ShelterModels;
using shelter.Models.UserModels;

namespace shelter.Interfaces.Shelter
{
    public interface IShelterService
    {
        Task<ShelterLoginDto> CreateAccount(string email);
        Task<bool> CreateUserShelter(string email);
        string GenerateTokenString(ShelterLoginDto shelter);
        Task<bool> LoginUser(ShelterLoginDto shelter);
        Task<bool> AddShelterDetailsForm(ShelterForm shelterForm);
        Task<List<PetsBelongsToShelterDto>> GetAllPetsBelongsToShelter(string shelterEmail);
        Task<ShelterForm> GetSingleShelter ( string shelterEmail);
        Task<string> ResetPassworReq(ResetPasswordReqModel resetPasswordReqModel);
        Task<bool> ResetPassword(ResetPasswordModel resetPasswordModel);
    }
}
