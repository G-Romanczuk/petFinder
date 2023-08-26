using shelter.Models.UserModels;
using shelter.UserDtos;

namespace shelter.Interfaces.User
{
    public interface IUserService
    {
        Task<bool> RegisterUser(UserRegisterDto user);
        Task<bool> CreateUser(UserRegisterDto user);
        Task<bool> LoginUser(UserLoginDto user);
    }
}
