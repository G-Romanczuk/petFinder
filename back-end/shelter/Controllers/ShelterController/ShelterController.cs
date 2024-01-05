using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Dtos.ShelterDtos;
using shelter.Interfaces.Shelter;
using shelter.Models.ShelterModels;
using shelter.Models.UserModels;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace shelter.Controllers.ShelterController
{
    [Route("/[controller]")]
    [ApiController]
    [SwaggerTag("Opis kontrolera")]
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

        [HttpPost("DetailsForm", Name = "AddShelterDetailsForm")]
        public async Task<IActionResult> AddShelterDetailsForm([FromBody] ShelterForm shelterForm)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _shelterService.AddShelterDetailsForm(shelterForm)) return Ok(new {message="Success"});

            return BadRequest();
        }

        [HttpPost("Create", Name = "CreateShelterCredentials")]
        public async Task<IActionResult> CreateShelterCredentials([FromBody] string email)
        {
            try
            {
                var shelterCredentials = await _shelterService.CreateAccount(email);
                await _shelterService.CreateUserShelter(email);
                return Ok(new {message="Success", shelterCredentials });
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
                return Ok(new { message = "Success", jwtToken });
            }
            return BadRequest();
        }

        [HttpGet("GetPets", Name ="GetAllPetsBelongsToShelter")]
        public async Task<IActionResult> GetAllPetsBelongsToShelter ([FromQuery] string shelterEmail)
        {
            try
            {
                var pets = await _shelterService.GetAllPetsBelongsToShelter(shelterEmail);
                

                if (pets.Count>0 || pets != null)
                {
                    return Ok(pets);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("Get", Name = "GetSingleShelter")]
        public async Task<IActionResult> GetSingleShelter([FromQuery] string email)
        {
            try
            {
                var shelter = await _shelterService.GetSingleShelter(email);

                if (shelter == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(shelter);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost("ResetShelterPasswordRequest", Name = "ResetShelterPasswordReq")]
        public async Task<IActionResult> ResetPasswordReq([FromBody] ResetPasswordReqModel resetPasswordReq)
        {
            var token = await _shelterService.ResetPassworReq(resetPasswordReq);

            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }

            if (token == null)
            {
                return NotFound("Error while generating token");
            }

            return Ok(token);
        }

        [HttpPost("ResetShelterPassword", Name = "ResetShelterPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel resetPassword)
        {
            var success = await _shelterService.ResetPassword(resetPassword);

            if (success)
            {
                return Ok("New Password Created Succesfully");
            }
            else
            {
                return BadRequest("Error while changing the password");
            }
        }

        [HttpGet("GetDogs", Name = "GetAllDogsBelongsToShelter")]
        public async Task<IActionResult> GetAllDogsBelongsToShelter([FromQuery] string shelterEmail)
        {
            try
            {
                var pets = await _shelterService.GetAllDogsBelongsToShelter(shelterEmail);


                if (pets.Count > 0 || pets != null)
                {
                    return Ok(pets);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("GetCats", Name = "GetAllCatsBelongsToShelter")]
        public async Task<IActionResult> GetAllCatsBelongsToShelter([FromQuery] string shelterEmail)
        {
            try
            {
                var pets = await _shelterService.GetAllCatsBelongsToShelter(shelterEmail);


                if (pets.Count > 0 || pets != null)
                {
                    return Ok(pets);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("GetRodents", Name = "GetAllRodentsBelongsToShelter")]
        public async Task<IActionResult> GetAllRodentsBelongsToShelter([FromQuery] string shelterEmail)
        {
            try
            {
                var pets = await _shelterService.GetAllRodentsBelongsToShelter(shelterEmail);


                if (pets.Count > 0 || pets != null)
                {
                    return Ok(pets);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
