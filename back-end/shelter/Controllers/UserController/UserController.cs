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
                return Ok( new { JwtToken,  message = "Success" });
            }
            return BadRequest(new { message = "Email or password is incorrect" });

        }

        [HttpPost("DetailsForm", Name = "AddUserDetailsForm")]
        public async Task<IActionResult> AddUserDetailsForm([FromBody] UserForm userForm)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _userService.AddUserDetailsForm(userForm))
            {
                return Ok(new {message = "Success"});
            }
            return BadRequest(new { message = "Wrong Data" });
        }

        [HttpPost("ResetPasswordRequest", Name = "ResetPasswordReq")]
        public async Task<IActionResult> ResetPasswordReq([FromBody] ResetPasswordReqModel resetPasswordReq)
        {
            var token = await _userService.ResetPasswordReq(resetPasswordReq);

            if (!ModelState.IsValid) return BadRequest();

            if (token == null)
            {
                return NotFound("Error while generating token");
            }

            return Ok(token);

        }

        [HttpPost("ResetPassword", Name = "ResetUserPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetPassword)
        {
            var success = await _userService.ResetPassword(resetPassword);

            if (success)
            {
                return Ok("New Password Created Succesfully");
            }
            else
            {
                return BadRequest("Error while changing the password");
            }
        }

        [HttpGet("Get",Name = "GetSingleUser")]
        public async Task<IActionResult> GetSingleUser([FromQuery] string email)
        {
            try
            {
                var user = await _userService.GetSignleUser(email);

                if (user==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(user);    
                }
            }
            catch (Exception)
            {

                return BadRequest();    
            }
        }

        [HttpGet("LikedPets",Name = "GetLikedPetsByUser")]
        public async Task<IActionResult> GetLikedPetsByUser([FromQuery] string userEmail)
        {
            var likedPets = await _userService.GetLikedPetsByUser(userEmail);
            if (likedPets == null)
            {
                return NotFound();
            }
           return Ok(likedPets);
        }



    }
}
