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

        [HttpPost("register" , Name ="RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
        {
            try
            {
                bool created = await _userService.CreateUser(userRegisterDto);
                return Ok($"{created}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Błąd: {ex.Message}");
            }
        }

        [HttpPost("login", Name = "LoginUser")]
        public async Task <IActionResult> LoginUser([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                var user = await _userService.LoginUser(userLoginDto.Email, userLoginDto.Password);
                if (user != null)
                {
                    //Return JWT

                    return Ok("Użytkownik zalogowany pomyślnie.");
                }
                else
                {
                    return Unauthorized("Nieprawidłowe dane logowania.");
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Błąd: {ex.Message}");
            }
        }
    }
}
