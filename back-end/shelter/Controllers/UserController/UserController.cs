using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Dtos.UserDtos;
using shelter.Interfaces.User;
using shelter.Models.UserModels;
using System.Text.Json;

namespace shelter.Controllers.UserController
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController
        (
            IMapper mapper,
            IUserService userService
        )
        {
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

            return BadRequest(new { message = "User already exist" }); 



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
            return BadRequest(new { message = "Email or password is incorrect" });

        }

    }
}
