using shelter.Models.UserModels;
using shelter.UserDtos;

namespace shelter.Interfaces.User
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserRegisterDto user);
    }
}
