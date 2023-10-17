using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using shelter.DataBaseContext.UserDbContext;
using shelter.Dtos.UserDtos;
using shelter.Models.UserModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace shelter.Interfaces.User
{
    public class UserService : IUserService
    {
        private readonly UserDbContext _userDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
     
        public UserService
        (
            UserManager<IdentityUser> userManager,
            UserDbContext userDbContext,
            IMapper mapper,
            IConfiguration configuration
        )
        {
            _userDbContext = userDbContext;
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
               
                var userModelToUpdate = await _userDbContext.Users.FirstOrDefaultAsync(um => um.Email == userModel.Email);
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
                await _userDbContext.SaveChangesAsync();

                var userHabbitsModelToUpdate = await _userDbContext.Habbits.FirstOrDefaultAsync(uid => uid.UserModelId == userModelToUpdateId);
                if (userHabbitsModelToUpdate == null)
                {
                    userHabbitsModel.UserModelId = userModelToUpdateId;
                    _userDbContext.Habbits.Add(userHabbitsModel);
                    await _userDbContext.SaveChangesAsync();
                }
                else
                {
                    userHabbitsModelToUpdate.Lifestyle = userHabbitsModel.Lifestyle;
                    userHabbitsModelToUpdate.HoursAlone = userHabbitsModel.HoursAlone;
                    userHabbitsModelToUpdate.WalksNumber = userHabbitsModel.WalksNumber;
                    userHabbitsModelToUpdate.WalksTime = userHabbitsModel.WalksTime;
                    userHabbitsModelToUpdate.Text = userHabbitsModel.Text;
                    await _userDbContext.SaveChangesAsync();
                }

                var userResidenceModelToUpdate = await _userDbContext.Residences.FirstOrDefaultAsync(uid => uid.UserModelId == userModelToUpdateId);
                if (userResidenceModelToUpdate == null)
                {
                    userResidenceModel.UserModelId = userModelToUpdateId;
                    _userDbContext.Residences.Add(userResidenceModel);
                    await _userDbContext.SaveChangesAsync();
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
                    await _userDbContext.SaveChangesAsync();
                }

                var userDogDetailsModelToUpdate = await _userDbContext.usersDogDetails.FirstOrDefaultAsync(uid => uid.UserModelId == userModelToUpdateId);
                if (userDogDetailsModelToUpdate == null)
                {
                    userDogDetailsModel.UserModelId = userModelToUpdateId;
                    _userDbContext.Add(userDogDetailsModel);
                    await _userDbContext.SaveChangesAsync();
                }
                else
                {
                    userDogDetailsModelToUpdate.PetPlace = userDogDetailsModel.PetPlace;
                    userDogDetailsModelToUpdate.PetPlaceAlone = userDogDetailsModel.PetPlaceAlone;
                    userDogDetailsModelToUpdate.CareAlone = userDogDetailsModel.CareAlone;
                    userDogDetailsModelToUpdate.AnimalsBefore = userDogDetailsModel.AnimalsBefore;
                    userDogDetailsModelToUpdate.AnimalsBeforeText = userDogDetailsModel.AnimalsBeforeText;
                    await _userDbContext.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public async Task<bool> CreateUser(UserRegisterDto user)
        {
           
            var userToCreate = _mapper.Map<UserModel>(user);

            try
            {
               _userDbContext.Users.Add(userToCreate);
                await _userDbContext.SaveChangesAsync();
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

        
    }
}
