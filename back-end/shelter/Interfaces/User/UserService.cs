using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shelter.DataBaseContext.UserDbContext;
using shelter.Models.UserModels;
using shelter.UserDtos;
using System.Security.Cryptography;
using System.Text;

namespace shelter.Interfaces.User
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _userDbContext;
        private readonly IMapper _mapper;

        private async Task<bool> UserExists(string email)
        {
            return await _userDbContext.Users.AnyAsync(u => u.Email == email);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public UserService
        (
            UserDbContext userDbContext,
            IMapper mapper
        )
        {
            _userDbContext = userDbContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateUser(UserRegisterDto user)
        {
            if (user == null)
                return false;

            if (await UserExists(user.Email))
                return false;

            var newUser = _mapper.Map<UserModel>(user);

            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;


            try
            {
                _userDbContext.Users.Add(newUser);
                await _userDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
