using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace shelter.Controllers.AuthTestController
{   
  
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public string Get()
        {
            return "U reached me";
        }
        
    }

    
}
