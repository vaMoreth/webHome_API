using Microsoft.AspNetCore.Http.HttpResults;
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
        #region GetAll
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<HomeDTO>> GetHomes()
        {
            return Ok(HomeStore.homeList);
        }
        #endregion

        #region GetId
        [HttpGet("id", Name = "GetHome")]
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
        #endregion

        #region Post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<HomeDTO> CreateHome([FromBody]HomeDTO homeDTO)
        {
            #region Validators

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            if (HomeStore.homeList.FirstOrDefault(u => u.Name.ToLower() == homeDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Home name already Exists!");
                return BadRequest(ModelState);
            }


            if (homeDTO == null)
                return BadRequest();

            if (homeDTO.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            #endregion

            homeDTO.Id = HomeStore.homeList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            HomeStore.homeList.Add(homeDTO);

            return CreatedAtRoute("GetHome", new {id = homeDTO.Id }, homeDTO);
        }
        #endregion

        #region Delete
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("id", Name = "DeleteHome")]
        public IActionResult DeleteHome(int id) 
        {
            if (id == 0)
                return BadRequest();

            var home = HomeStore.homeList.FirstOrDefault(u => u.Id == id);

            if (home == null)
                return NotFound();

            HomeStore.homeList.Remove(home);
            return NoContent();
        }
        #endregion
    }
}
