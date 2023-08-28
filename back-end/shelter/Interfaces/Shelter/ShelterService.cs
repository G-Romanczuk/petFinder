using Microsoft.AspNetCore.Identity;
using shelter.DataBaseContext.ShelterDbContext;
using shelter.Dtos.ShelterDtos;
using System.Security.Cryptography;

namespace shelter.Interfaces.Shelter
{
    public class ShelterService : IShelterService
    {
        private readonly ShelterDbContext _shelterDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        public ShelterService
        (
            ShelterDbContext shelterDbContext,
            UserManager<IdentityUser> userManager
        )
        {
            _shelterDbContext = shelterDbContext;
            _userManager = userManager;
        }
        public async Task<ShelterLoginDto> CreateAccount(string email)
        {
            

            try
            {
                string generatedPassword = GenerateRandomPassword(9);
                var identityShelter = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                };

                var res = await _userManager.CreateAsync(identityShelter, "zaq1@WSX");
                if (res.Succeeded)
                {
                    var shelterCredentials = new ShelterLoginDto
                    {
                        email = email,
                        password = generatedPassword,
                    };

                    return shelterCredentials;
                }else
                {
                    return null;
                }
                

               
            }
            catch (Exception)
            {

                return null;
            }
        }

        static string GenerateRandomPassword(int length)
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=<>?";

            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];
                rngCryptoServiceProvider.GetBytes(randomBytes);

                char[] chars = new char[length];
                int allowedCharCount = allowedChars.Length;

                for (int i = 0; i < length; i++)
                {
                    chars[i] = allowedChars[randomBytes[i] % allowedCharCount];
                }

                return new string(chars);
            }
        }
    }
}
