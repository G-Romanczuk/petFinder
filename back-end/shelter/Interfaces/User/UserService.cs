using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using shelter.DataBaseContext.ShelterPetFinderDbContext;
using shelter.Dtos.UserDtos;
using shelter.Models.UserModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;

namespace shelter.Interfaces.User
{
    public class UserService : IUserService
    {
        private readonly ShelterPetFinderDbContext _shelterPetFinderDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
     
        public UserService
        (
            UserManager<IdentityUser> userManager,
            ShelterPetFinderDbContext shelterPetFinderDbContext,
            IMapper mapper,
            IConfiguration configuration
        )
        {
            _shelterPetFinderDbContext = shelterPetFinderDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;

        }
        public async Task<bool> AddUserDetailsForm(UserForm userForm)
        {
            var userModel = _mapper.Map<UserModel>( userForm );
            var userHabbitsModel = _mapper.Map<UserHabbitsModel>( userForm );
            var userResidenceModel = _mapper.Map<UserResidenceModel>( userForm );
            var userDogDetailsModel = _mapper.Map<UsersDogDetailsModel>( userForm );

            try
            {
               
                var userModelToUpdate = await _shelterPetFinderDbContext.RegisteredUsers.FirstOrDefaultAsync(um => um.Email == userModel.Email);
                if ( userModelToUpdate == null )
                {
                    return false;
                }

                var userModelToUpdateId = userModelToUpdate.Id;

              
                userModelToUpdate.Id = userModelToUpdateId;
                userModelToUpdate.Name = userModel.Name;
                userModelToUpdate.Lname = userModel.Lname;
                userModelToUpdate.Email = userModel.Email;
                userModelToUpdate.Phone = userModel.Phone;
                userModelToUpdate.PostCode = userModel.PostCode;
                userModelToUpdate.Town = userModel.Town;
                userModelToUpdate.Adress = userModel.Adress;
                userModelToUpdate.IncomeSource = userModel.IncomeSource;
                await _shelterPetFinderDbContext.SaveChangesAsync();

                var userHabbitsModelToUpdate = await _shelterPetFinderDbContext.Habbits.FirstOrDefaultAsync(uid => uid.UserModelId == userModelToUpdateId);
                if (userHabbitsModelToUpdate == null)
                {
                    userHabbitsModel.UserModelId = userModelToUpdateId;
                    _shelterPetFinderDbContext.Habbits.Add(userHabbitsModel);
                    await _shelterPetFinderDbContext.SaveChangesAsync();
                }
                else
                {
                    userHabbitsModelToUpdate.Lifestyle = userHabbitsModel.Lifestyle;
                    userHabbitsModelToUpdate.HoursAlone = userHabbitsModel.HoursAlone;
                    userHabbitsModelToUpdate.WalksNumber = userHabbitsModel.WalksNumber;
                    userHabbitsModelToUpdate.WalksTime = userHabbitsModel.WalksTime;
                    userHabbitsModelToUpdate.Text = userHabbitsModel.Text;
                    await _shelterPetFinderDbContext.SaveChangesAsync();
                }

                var userResidenceModelToUpdate = await _shelterPetFinderDbContext.Residences.FirstOrDefaultAsync(uid => uid.UserModelId == userModelToUpdateId);
                if (userResidenceModelToUpdate == null)
                {
                    userResidenceModel.UserModelId = userModelToUpdateId;
                    _shelterPetFinderDbContext.Residences.Add(userResidenceModel);
                    await _shelterPetFinderDbContext.SaveChangesAsync();
                }
                else
                {
                    userResidenceModelToUpdate.HousingType = userResidenceModel.HousingType;
                    userResidenceModelToUpdate.HouseOwner = userResidenceModel.HouseOwner;
                    userResidenceModelToUpdate.Floor = userResidenceModel.Floor;
                    userResidenceModelToUpdate.Elevator = userResidenceModel.Elevator;
                    userResidenceModelToUpdate.Fence = userResidenceModel.Fence;
                    userResidenceModelToUpdate.FenceHeight = userResidenceModel.FenceHeight;
                    userResidenceModelToUpdate.PropertySize = userResidenceModel.PropertySize;
                    userResidenceModelToUpdate.HouseMates = userResidenceModel.HouseMates;
                    userResidenceModelToUpdate.Animals = userResidenceModel.Animals;
                    await _shelterPetFinderDbContext.SaveChangesAsync();
                }

                var userDogDetailsModelToUpdate = await _shelterPetFinderDbContext.usersDogDetails.FirstOrDefaultAsync(uid => uid.UserModelId == userModelToUpdateId);
                if (userDogDetailsModelToUpdate == null)
                {
                    userDogDetailsModel.UserModelId = userModelToUpdateId;
                    _shelterPetFinderDbContext.Add(userDogDetailsModel);
                    await _shelterPetFinderDbContext.SaveChangesAsync();
                }
                else
                {
                    userDogDetailsModelToUpdate.PetPlace = userDogDetailsModel.PetPlace;
                    userDogDetailsModelToUpdate.PetPlaceAlone = userDogDetailsModel.PetPlaceAlone;
                    userDogDetailsModelToUpdate.CareAlone = userDogDetailsModel.CareAlone;
                    userDogDetailsModelToUpdate.AnimalsBefore = userDogDetailsModel.AnimalsBefore;
                    userDogDetailsModelToUpdate.AnimalsBeforeText = userDogDetailsModel.AnimalsBeforeText;
                    await _shelterPetFinderDbContext.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<bool> CreateUser(UserRegisterDto user)
        {
           
            var userToCreate = _mapper.Map<UserModel>(user);

            try
            {
                _shelterPetFinderDbContext.RegisteredUsers.Add(userToCreate);
                await _shelterPetFinderDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return  false;
            }
           
        }

        public async Task<bool> RegisterUser(UserRegisterDto user)
        {
            try
            {
                var identityUser = new IdentityUser
                {
                    UserName = user.Email,
                    Email = user.Email,
                };

                var res = await _userManager.CreateAsync(identityUser, user.Password);

                return res.Succeeded;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public async Task<bool> LoginUser(UserLoginDto user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.EmailUser);
            if (identityUser == null) return false;

           return await _userManager.CheckPasswordAsync(identityUser, user.PasswordUser);
        }

        public string GenerateTokenString(UserLoginDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email , user.EmailUser),
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

        public async Task<string> ResetPassowrdToken(ResetPasswordModel email)
        {
            var user = await GetUserFromUserManager(email.Email);

            if (user == null)
            {
                return "Podany uzytkownik o danym Email nie istnieje";
            }
            return await _userManager.GeneratePasswordResetTokenAsync(user);

        }

        public async Task<bool> ResetPassword(ResetPasswordModel resetPassword)
        {
            var user = await GetUserFromUserManager(resetPassword.Email);

            if (user != null)
            {
                var res = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.NewPassword);

                if (res.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<IdentityUser?> GetUserFromUserManager(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

    }
}
