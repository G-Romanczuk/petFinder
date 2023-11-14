using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace shelter.Controllers.AuthTestController
{   
    public class Klasa
    {        
        public string emailShelter { get; set; }
        public string passwordShelter { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {
        // [Authorize]
        //[HttpGet]
        //public string Get()
        //{
        //    return "U reached me";
        //}
        [HttpPost]
        public async Task<IActionResult> img(IFormFile formFile)
        {
            return Ok(formFile);
        }
    }
}

    

