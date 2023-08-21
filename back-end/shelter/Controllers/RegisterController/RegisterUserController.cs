using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Models.UserModels;
using shelter.UserDtos;

namespace shelter.Controllers.RegisterController
{
    [Route("shelter/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        [HttpPost(Name ="CreateUser")]
        public IActionResult RegisterUser([FromBody] UserRegisterDto userRegisterDto)
        {
            return Ok(userRegisterDto);
        }
    }
}
