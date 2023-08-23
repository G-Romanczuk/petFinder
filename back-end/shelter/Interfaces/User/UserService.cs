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
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                        return false;
                }
            }
            return true;
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

        public async Task<UserModel> LoginUser(string email, string password)
        {
            var user = await _userDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;

        }
    }
}
