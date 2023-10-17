using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Dtos.PetDtos;
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
        public async Task<IActionResult> AddPet([FromBody] PetForm pet)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (await _petService.AddPetForm(pet))
            {
                return Ok("Pet was added to the database");
            }
            
            return BadRequest();
                

        }
    }
}
