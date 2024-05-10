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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<HomeDTO>> GetHomes()
        {
            return Ok(HomeStore.homeList);
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<HomeDTO> GetHome(int id)
        {
            if (id == 0)
                return BadRequest();

            var home = HomeStore.homeList.FirstOrDefault(u=>u.Id==id);

            if (home == null)
                return NotFound();

            return Ok(home);
        }
    }
}
