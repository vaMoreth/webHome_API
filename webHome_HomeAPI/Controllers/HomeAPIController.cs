using Microsoft.AspNetCore.Mvc;
using webHome_HomeAPI.Data;
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
            return HomeStore.homeList;
        }

        [HttpGet("id")]
        public HomeDTO GetHome(int id)
        {
            return HomeStore.homeList.FirstOrDefault(u=>u.Id==id);
        }
    }
}
