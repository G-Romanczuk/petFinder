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
               
                var userModelToUpdate = await _shelterPetFinderDbContext.UsersRegistered.FirstOrDefaultAsync(um => um.Email == userModel.Email);
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

                var userHabbitsModelToUpdate = await _shelterPetFinderDbContext.UserQuestionsHabbits.FirstOrDefaultAsync(uid => uid.UserModelId == userModelToUpdateId);
                if (userHabbitsModelToUpdate == null)
                {
                    userHabbitsModel.UserModelId = userModelToUpdateId;
                    _shelterPetFinderDbContext.UserQuestionsHabbits.Add(userHabbitsModel);
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

                var userResidenceModelToUpdate = await _shelterPetFinderDbContext.UserQuestionsResidence.FirstOrDefaultAsync(uid => uid.UserModelId == userModelToUpdateId);
                if (userResidenceModelToUpdate == null)
                {
                    userResidenceModel.UserModelId = userModelToUpdateId;
                    _shelterPetFinderDbContext.UserQuestionsResidence.Add(userResidenceModel);
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

                var userDogDetailsModelToUpdate = await _shelterPetFinderDbContext.UserQuestionsPetDetails.FirstOrDefaultAsync(uid => uid.UserModelId == userModelToUpdateId);
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
                _shelterPetFinderDbContext.UsersRegistered.Add(userToCreate);
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

        public async Task<IdentityUser?> GetUserFromUserManager(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<string> ResetPasswordReq(ResetPasswordReqModel resetPasswordReqModel)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordReqModel.Email);

            if (user==null)
            {
                return "User Not Found";
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return token;
        }

        public async Task<bool> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);

            if (user == null)
            {
                return false;
            }

            var res = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.NewPassword);

            return res.Succeeded;
        }

        public async Task<UserForm> GetSignleUser(string email)
        {
            var userModel = await _shelterPetFinderDbContext.UsersRegistered.FirstOrDefaultAsync(u=>u.Email == email);
            if (userModel!=null)
            {
                var userModelId = userModel.Id;

                var userHabbits = await _shelterPetFinderDbContext.UserQuestionsHabbits.FirstOrDefaultAsync(u => u.UserModelId == userModelId);
                var userResidence = await _shelterPetFinderDbContext.UserQuestionsResidence.FirstOrDefaultAsync(u => u.UserModelId == userModelId);
                var userPetDetails = await _shelterPetFinderDbContext.UserQuestionsPetDetails.FirstOrDefaultAsync(u => u.UserModelId == userModelId);

                var userToGet = _mapper.Map<UserForm>(userModel);
                _mapper.Map(userHabbits, userToGet);
                _mapper.Map(userResidence, userToGet);
                _mapper.Map(userPetDetails, userToGet);

                return userToGet;
            }
            else
            {
                return null;
            }
            
        }
    }
}
