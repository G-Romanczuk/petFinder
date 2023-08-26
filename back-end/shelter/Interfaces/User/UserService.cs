using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using shelter.DataBaseContext.UserDbContext;
using shelter.Models.UserModels;
using shelter.UserDtos;
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
            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            if (identityUser == null) return false;

           return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public string GenerateTokenString(UserLoginDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email , user.Email),
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
