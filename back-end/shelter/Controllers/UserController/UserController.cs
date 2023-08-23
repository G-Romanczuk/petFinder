using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Models.UserModels;
using shelter.UserDtos;
using System.Text.Json;

namespace shelter.Controllers.UserController
{
    [Route("shelter/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost(Name ="CreateUser")]
        public async Task<IActionResult> RegisterUser([FromBody] JsonElement user)
        {
            try
            {
                var userToRegister = _mapper.Map<UserModel>(user);
                return Ok(userToRegister);
            }
            catch (Exception ex)
            {

                return BadRequest($"Błąd: {ex.Message}");
            }
        }
    }
}
