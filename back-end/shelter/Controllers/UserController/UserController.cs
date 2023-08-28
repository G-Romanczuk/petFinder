using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Interfaces.User;
using shelter.Models.UserModels;
using shelter.UserDtos;
using System.Text.Json;

namespace shelter.Controllers.UserController
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController
        (
            IMapper mapper,
            IUserService userService
        )
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("Register",Name ="RegisterUser")]
        public async Task<IActionResult> RegisterUser ([FromBody]UserRegisterDto user)
        {
            if (await _userService.RegisterUser(user))
            {
                await _userService.CreateUser(user);
                return Ok("Your account has been created succesfully");
            }

            return BadRequest();
            
            
        }

        [HttpPost("Login", Name ="LoginUser")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _userService.LoginUser(user))
            {
                var JwtToken = _userService.GenerateTokenString(user);
                return Ok(JwtToken);
            }
            return BadRequest();
            
        }

    }
}
