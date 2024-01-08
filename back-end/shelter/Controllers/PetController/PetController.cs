using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> DeletePet([FromBody] int id)
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


    }
}
