using Microsoft.AspNetCore.Mvc;
using webHome_HomeAPI.Models;

namespace webHome_HomeAPI.Controllers
{
    [Route("api/HomeAPI")]
    [ApiController]
    public class HomeAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Home> GetHomes()
        {
            return new List<Home>() { 
                new Home { Id = 1, Name = "Home 1" },
                new Home { Id = 2, Name = "Home 2" }
            };
            
        }
    }
}
