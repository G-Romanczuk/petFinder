﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("DetailsForm", Name = "AddShelterDetailsForm")]
        public async Task<IActionResult> AddShelterDetailsForm([FromBody] ShelterForm shelterForm)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _shelterService.AddShelterDetailsForm(shelterForm)) return Ok();

            return BadRequest();
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

        [HttpGet("GetPets", Name ="GetAllPetsBelongsToShelter")]
        public async Task<IActionResult> GetAllPetsBelongsToShelter ([FromQuery] string shelterEmail)
        {
            try
            {
                var pets = await _shelterService.GetAllPetsBelongsToShelter(shelterEmail);

                if (pets.Count>0)
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
    }
}
