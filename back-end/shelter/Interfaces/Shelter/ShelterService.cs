using AutoMapper;
using Microsoft.AspNetCore.Identity;
using shelter.DataBaseContext.ShelterDbContext;
using shelter.Dtos.ShelterDtos;
using shelter.Models.ShelterModels;
using System.Security.Cryptography;

namespace shelter.Interfaces.Shelter
{ 
    public class ShelterService : IShelterService
    {
        private readonly ShelterDbContext _shelterDbContext;
        private readonly UserManager<IdentityUser> _userManagerShelter;
        private readonly IMapper _mapper;

        public ShelterService
        (
            ShelterDbContext shelterDbContext,
            UserManager<IdentityUser> userManagerShelter,
            IMapper mapper

        )
        {
            _shelterDbContext = shelterDbContext;
            _userManagerShelter = userManagerShelter;
            _mapper = mapper;
        }

        public async Task<bool> CreateUserShelter(string email)
        {
            var ShelterUserToCreate = new ShelterModel
            {
                Email = email,
            };

            try
            {
                _shelterDbContext.Shelters.Add( ShelterUserToCreate );
                await _shelterDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

                var res = await _userManagerShelter.CreateAsync(identityShelter, generatedPassword);

                if (res.Succeeded)
                {
                    var shelterCredentials = new ShelterLoginDto
                    {
                        email = email,
                        password = generatedPassword,
                    };

                    return shelterCredentials;
                }
                else
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
