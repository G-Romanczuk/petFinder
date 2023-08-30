using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Dtos.ShelterDtos;
using shelter.Interfaces.Shelter;

namespace shelter.Controllers.UserController
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

    }
}
