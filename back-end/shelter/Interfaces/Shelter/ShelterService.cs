using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using shelter.DataBaseContext.ShelterDbContext;
using shelter.Dtos.ShelterDtos;
using shelter.Dtos.UserDtos;
using shelter.Models.ShelterModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace shelter.Interfaces.Shelter
{ 
    public class ShelterService : IShelterService
    {
        private readonly ShelterDbContext _shelterDbContext;
        private readonly UserManager<IdentityUser> _userManagerShelter;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ShelterService
        (
            ShelterDbContext shelterDbContext,
            UserManager<IdentityUser> userManagerShelter,
            IMapper mapper,
            IConfiguration configuration

        )
        {
            _shelterDbContext = shelterDbContext;
            _userManagerShelter = userManagerShelter;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<bool> AddShelterDetailsForm(ShelterForm shelterForm)
        {
            var shelterModel = _mapper.Map<ShelterModel>( shelterForm );
            var shelterHabbitsModel = _mapper.Map<ShelterHabbitsModel>( shelterForm );
            var shelterResidenceModel = _mapper.Map<ShelterResidenceModel>( shelterForm );
            var shrelterPetDetailsModel = _mapper.Map<ShelterPetDetailsModel>( shelterForm );
            try
            {
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> LoginUser(ShelterLoginDto shelter)
        {
            var identityShelterUser = await _userManagerShelter.FindByEmailAsync( shelter.EmailShelter );
            if ( identityShelterUser == null )
            {
                return false;
            }

            return await _userManagerShelter.CheckPasswordAsync(identityShelterUser, shelter.PasswordShelter);
        }

        public async Task<bool> CreateUserShelter(string email)
        {
            var emailAlreadyExist = _shelterDbContext.Shelters.Any(shelter => shelter.Email == email );

            if ( emailAlreadyExist )
            {
                return false;
            }
            else
            {
                var ShelterUserToCreate = new ShelterModel
                {
                    Email = email,
                };


                _shelterDbContext.Shelters.Add(ShelterUserToCreate);
                await _shelterDbContext.SaveChangesAsync();
                return true;
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
                        EmailShelter = email,
                        PasswordShelter = generatedPassword,
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

        public string GenerateTokenString(ShelterLoginDto shelter)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email , shelter.EmailShelter),
                new Claim(ClaimTypes.Role, "Admin"),
            };


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken securityToken = new JwtSecurityToken(
            claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCredentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }

       
    }
}
