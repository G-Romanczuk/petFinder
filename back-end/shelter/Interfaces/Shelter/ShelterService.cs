using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using shelter.DataBaseContext.PetDbContext;
using shelter.DataBaseContext.ShelterDbContext;
using shelter.DataBaseContext.UserDbContext;
using shelter.Dtos.ShelterDtos;
using shelter.Dtos.UserDtos;
using shelter.Models.PetModels;
using shelter.Models.ShelterModels;
using shelter.Models.UserModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace shelter.Interfaces.Shelter
{ 
    public class ShelterService : IShelterService
    {
        private readonly ShelterDbContext _shelterDbContext;
        private readonly PetDbContext _petDbContext;
        private readonly UserManager<IdentityUser> _userManagerShelter;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IOptions<PasswordHasherOptions> _passwordHasherOptions;

        public ShelterService
        (
            ShelterDbContext shelterDbContext,
            PetDbContext petDbContext,
            UserManager<IdentityUser> userManagerShelter,
            IMapper mapper,
            IConfiguration configuration,
            IOptions<PasswordHasherOptions> passwordHasherOptions

        )
        {
            _shelterDbContext = shelterDbContext;
            _petDbContext = petDbContext;
            _userManagerShelter = userManagerShelter;
            _mapper = mapper;
            _configuration = configuration;
            _passwordHasherOptions = passwordHasherOptions;
        }
        public async Task<bool> AddShelterDetailsForm(ShelterForm shelterForm)
        {
            var shelterModel = _mapper.Map<ShelterModel>( shelterForm );
            var shelterHabbitsModel = _mapper.Map<ShelterHabbitsModel>( shelterForm.Questions );
            var shelterResidenceModel = _mapper.Map<ShelterResidenceModel>( shelterForm.Questions );
            var shelterPetDetailsModel = _mapper.Map<ShelterPetDetailsModel>( shelterForm.Questions );
            try
            {
                var shelterModelToUpdate = await _shelterDbContext.Shelters.FirstOrDefaultAsync(se=>se.Email == shelterModel.Email);
                if (shelterModelToUpdate == null)
                {
                    return false;
                }

                shelterModelToUpdate.Id = shelterModelToUpdate.Id;
                shelterModelToUpdate.Name = shelterModel.Name;
                shelterModelToUpdate.Email = shelterModel.Email;
                shelterModelToUpdate.Phone = shelterModel.Phone;
                shelterModelToUpdate.PostCode = shelterModel.PostCode;
                shelterModelToUpdate.Town = shelterModel.Town;
                shelterModelToUpdate.Adress = shelterModel.Adress;
                shelterModelToUpdate.Url = shelterModel.Url;
                await _shelterDbContext.SaveChangesAsync();

                var shelterHabbitsModelToUpdate = await _shelterDbContext.ShelterQuestionsHabbits.FirstOrDefaultAsync(sid=>sid.ShelterModelId == shelterModelToUpdate.Id);
                if (shelterHabbitsModelToUpdate == null)
                {
                    shelterHabbitsModel.ShelterModelId = shelterModelToUpdate.Id;
                    _shelterDbContext.ShelterQuestionsHabbits.Add(shelterHabbitsModel);
                    await _shelterDbContext.SaveChangesAsync();
                }
                else
                {
                    shelterHabbitsModelToUpdate.Lifestyle = shelterHabbitsModel.Lifestyle;
                    shelterHabbitsModelToUpdate.HoursAlone = shelterHabbitsModel.HoursAlone;
                    shelterHabbitsModelToUpdate.WalksNumber = shelterHabbitsModel.WalksNumber;
                    shelterHabbitsModelToUpdate.WalksTime = shelterHabbitsModel.WalksTime;
                    shelterHabbitsModelToUpdate.Text = shelterHabbitsModel.Text;
                    await _shelterDbContext.SaveChangesAsync();
                }

                var shelterResidenceModelToUpdate = await _shelterDbContext.ShelterQuestionsResidence.FirstOrDefaultAsync(sid => sid.ShelterModelId == shelterModelToUpdate.Id);
                if (shelterResidenceModelToUpdate == null)
                {
                    shelterResidenceModel.ShelterModelId = shelterModelToUpdate.Id;
                    _shelterDbContext.ShelterQuestionsResidence.Add(shelterResidenceModel);
                    await _shelterDbContext.SaveChangesAsync();
                }
                else
                {
                    shelterResidenceModelToUpdate.IncomeSource = shelterResidenceModel.IncomeSource;
                    shelterResidenceModelToUpdate.HousingType = shelterResidenceModel.HousingType;
                    shelterResidenceModelToUpdate.HouseOwner = shelterResidenceModel.HouseOwner;
                    shelterResidenceModelToUpdate.Floor = shelterResidenceModel.Floor;
                    shelterResidenceModelToUpdate.Elevator = shelterResidenceModel.Elevator;
                    shelterResidenceModelToUpdate.Fence = shelterResidenceModel.Fence;
                    shelterResidenceModelToUpdate.FenceHeight = shelterResidenceModel.FenceHeight;
                    shelterResidenceModelToUpdate.PropertySize = shelterResidenceModel.PropertySize;
                    shelterResidenceModelToUpdate.HouseMates = shelterResidenceModel.HouseMates;
                    shelterResidenceModelToUpdate.Animals = shelterResidenceModel.Animals;
                    await _shelterDbContext.SaveChangesAsync();
                }

                var shelterPetDetailsModelToUpdate = await _shelterDbContext.ShelterQuestionsPetDetails.FirstOrDefaultAsync(sid => sid.ShelterModelId == shelterModelToUpdate.Id);
                if (shelterPetDetailsModelToUpdate == null)
                {
                    shelterPetDetailsModel.ShelterModelId = shelterModelToUpdate.Id;
                    _shelterDbContext.Add(shelterPetDetailsModel);
                    await _shelterDbContext.SaveChangesAsync();
                }
                else
                {
                    shelterPetDetailsModelToUpdate.PetPlace = shelterPetDetailsModel.PetPlace;
                    shelterPetDetailsModelToUpdate.PetPlaceAlone = shelterPetDetailsModel.PetPlaceAlone;
                    shelterPetDetailsModelToUpdate.CareAlone = shelterPetDetailsModel.CareAlone;
                    shelterPetDetailsModelToUpdate.AnimalsBefore = shelterPetDetailsModel.AnimalsBefore;
                    shelterPetDetailsModelToUpdate.AnimalsBeforeText = shelterPetDetailsModel.AnimalsBeforeText;
                    await _shelterDbContext.SaveChangesAsync();
                }

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
                var shelterRegisterForm = new ShelterRegisterForm
                {
                    Email = email,
                };

                var shelterUserToCreate = _mapper.Map<ShelterModel>(shelterRegisterForm);

                _shelterDbContext.Shelters.Add(shelterUserToCreate);
                await _shelterDbContext.SaveChangesAsync();
                return true;
            }
            
           
        }

        public async Task<ShelterLoginDto> CreateAccount(string email)
        {
            try
            {
                string generatedPassword = GeneratePassword(email);
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

        public async Task<List<PetModel>> GetAllPetsBelongsToShelter(string shelterEmail)
        {
            var shelterId = await _shelterDbContext.Shelters
                .Where(shEmail => shEmail.Email == shelterEmail)
                .Select(shId => shId.Id)
                .FirstOrDefaultAsync();

            if (shelterId != 0)
            {
                return await _petDbContext.Pets
                    .Where(shId => shId.ShelterModelId == shelterId)
                    .ToListAsync();
            }
            else
            {
                return new List<PetModel>();
            }
        }

        public string GeneratePassword(string password)
        {
            var passwordHasher = new PasswordHasher<IdentityUser>(_passwordHasherOptions);
            var hashedPassword = passwordHasher.HashPassword(null, password);
            return hashedPassword;
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
