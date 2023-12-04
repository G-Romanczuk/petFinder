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

        [HttpPost("DetailsForm", Name = "AddUserDetailsForm")]
        public async Task<IActionResult> AddUserDetailsForm([FromBody] UserForm userForm)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _userService.AddUserDetailsForm(userForm))
            {
                return Ok();
            }
            return BadRequest(new { message = "Wrong Data" });
        }

        [HttpPost("ResetPassword", Name = "ResetUserPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetPasswordModel)
        {
            var resetTokenResult = await _userService.ResetPassowrdToken(resetPasswordModel);

            if (resetTokenResult.StartsWith("Podany uzytkownik o danym Email nie istnieje"))
            {
                return NotFound(new { Message = "Użytkownik o podanym adresie Email nie istnieje" });
            }

            var resetResult = await _userService.ResetPassword(resetPasswordModel);

            if (resetResult)
            {
                return Ok(new { Message = "Hasło zostało zresetowane pomyślnie." });
            }
            else
            {
                return BadRequest(new { Message = "Nie udało się zresetować hasła." });
            }
        }

    }
}
