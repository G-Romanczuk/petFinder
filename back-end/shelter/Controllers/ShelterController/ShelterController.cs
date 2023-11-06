using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.DataBaseContext.ShelterDbContext;
using shelter.Dtos.ShelterDtos;
using shelter.Interfaces.Shelter;
using shelter.Models.ShelterModels;
using System.Net.Mime;

namespace shelter.Controllers.ShelterController
{
    [Route("/[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        private readonly IShelterService _shelterService;

        public ShelterController
        (
            IShelterService shelterService
        )
        {
            _shelterService = shelterService;
        }

        [HttpPost("Create", Name = "CreateShelterCredentials")]
        public async Task<IActionResult> CreateShelterCredentials([FromBody] string email)
        {
            try
            {
                var shelterCredentials = await _shelterService.CreateAccount(email);
                await _shelterService.CreateUserShelter(email);
                return Ok(shelterCredentials);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Login", Name = "LoginShelterUser")]
        public async Task<IActionResult> Login(ShelterLoginDto shelter)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _shelterService.LoginUser(shelter))
            {
                var jwtToken = _shelterService.GenerateTokenString(shelter);
                return Ok(jwtToken);
            }
            return BadRequest();
        }
        
    }
}
