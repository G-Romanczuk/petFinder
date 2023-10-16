using shelter.Dtos.UserDtos;
using shelter.Models.UserModels;

namespace shelter.Interfaces.User
{
    public interface IUserService
    {
        Task<bool> RegisterUser(UserRegisterDto user);
        Task<bool> CreateUser(UserRegisterDto user);
        Task<bool> LoginUser(UserLoginDto user);
        Task<bool> AddUserDetailsForm(UserForm userForm);
        string GenerateTokenString(UserLoginDto user);
    }
}
