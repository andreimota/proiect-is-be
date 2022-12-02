using Microsoft.AspNetCore.Mvc;

namespace ProiectIS_BE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : ControllerBase
    { 
        public HelloWorldController()
        {
        }

        [HttpGet(Name = "GetHelloWorld")]
        public string Get()
        {
            return "Hello World";
        }
    }
}