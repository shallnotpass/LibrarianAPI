using Microsoft.AspNetCore.Mvc;

namespace LibrarianApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet(Name = "Home")]
        public string Get()
        {
            return "Hello world";
        }
    }
}
