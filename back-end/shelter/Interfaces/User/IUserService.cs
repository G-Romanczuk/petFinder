using shelter.UserDtos;

namespace shelter.Interfaces.User
{
    public interface IUserService
    {
        UserRegisterDto CreateUSer(UserRegisterDto userRegister);
        UserDto GetUserById(int userId);
    }
}
