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
    }
}
