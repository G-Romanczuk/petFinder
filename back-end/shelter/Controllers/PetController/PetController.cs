using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shelter.Dtos.PetsDtos;
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
        public async Task<IActionResult> AddPet([FromBody] PetDto pet)
        {
            if(await _petService.AddPet(pet))
            {
                await _petService.AddPet(pet);
                return Ok("Pet was added to the database");
            }

            return BadRequest();
        }
    }
}
