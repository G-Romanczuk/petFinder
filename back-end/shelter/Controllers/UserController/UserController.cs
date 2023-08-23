using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Interfaces.User;
using shelter.Models.UserModels;
using shelter.UserDtos;
using System.Text.Json;

namespace shelter.Controllers.UserController
{
    [Route("/user/register")]
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

        [HttpPost(Name ="CreateUser")]
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
    }
}
