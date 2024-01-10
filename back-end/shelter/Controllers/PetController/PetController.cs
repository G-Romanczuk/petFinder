﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Interfaces.Pet;
using shelter.Interfaces.User;
using shelter.Models.PetModels;

namespace shelter.Controllers.PetController
{
    [Route("/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController( IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost("Add", Name ="AddPet")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddPet([FromForm] PetForm pet)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (await _petService.AddPetForm(pet))
            {
                return Ok();
            }

            return BadRequest( new {message = "Wrong Data"});
        }

        [HttpPut("Update", Name = "UpdatePet")]
        public async Task<IActionResult> UpdatePet([FromForm] PetForm pet)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (await _petService.UpdatePet(pet))
            {
                return Ok();
            }
            return BadRequest(new { message = "Wrong Data" });
        }

        [HttpGet("GetAllPets", Name ="GetAllPetsFromDb")]
        public async Task<IActionResult> GetAllPets()
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                return Ok(await _petService.GetAllPets());
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Wystąpił błąd podczas pobierania zwierząt: {ex.Message}");

            }

        }

        [HttpDelete("Delete", Name ="DeletePet")]
        public async Task<IActionResult> DeletePet([FromQuery] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                return Ok(await _petService.DeletePet(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Wystapił bład podczas usuwania zwierzaka {ex.Message}");
            }
        }

        [HttpGet("GetSingle", Name ="GetSinglePetById")]
        public async Task<IActionResult> GetPetById([FromQuery] int id)
        {
            
            if (!ModelState.IsValid) return BadRequest();

            var pet = await _petService.GetPetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
           
        }

        [HttpPost("AddLikedPets", Name ="AddPetsLikedByUser")]
        public async Task<IActionResult> AddLikedPetList([FromBody] LikedPetListModel likedPetListModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (await _petService.AddLikedPetList(likedPetListModel))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("AllRodents",Name = "GetAllRodents")]
        public async Task<IActionResult> GetAllRodents()
        {
            try
            {
                var allRodents = _petService.GetAllRodents();
                return Ok(allRodents);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("AllDogs", Name = "GetAllDogs")]
        public async Task<IActionResult> GetAllDogs()
        {
            try
            {
                var allRodents = _petService.GetAllDogs();
                return Ok(allRodents);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("AllCats", Name = "GetAllCats")]
        public async Task<IActionResult> GetAllCats()
        {
            try
            {
                var allRodents = _petService.GetAllCats();
                return Ok(allRodents);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("AllOthers", Name = "GetAllOthersPets")]
        public async Task<IActionResult> GetAllOthersPets()
        {
            try
            {
                var allRodents = _petService.GetAllOtherPets();
                return Ok(allRodents);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
