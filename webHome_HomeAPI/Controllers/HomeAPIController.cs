using Microsoft.AspNetCore.Mvc;
using webHome_HomeAPI.Models;
using webHome_HomeAPI.Models.Dto;

namespace webHome_HomeAPI.Controllers
{
    [Route("api/HomeAPI")]
    [ApiController]
    public class HomeAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<HomeDTO> GetHomes()
        {
            return new List<HomeDTO>() { 
                new HomeDTO { Id = 1, Name = "Home 1" },
                new HomeDTO { Id = 2, Name = "Home 2" }
            };
            
        }
    }
}
