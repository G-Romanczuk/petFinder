using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;
     
        public UserService
        (
            UserManager<IdentityUser> userManager,
            UserDbContext userDbContext,
            IMapper mapper
        )
        {
            _userDbContext = userDbContext;
            _mapper = mapper;
            _userManager = userManager;
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
    }
}
