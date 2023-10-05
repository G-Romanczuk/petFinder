using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public string Pass(string test) 
        {
            return test;
        }
    }

    
}
