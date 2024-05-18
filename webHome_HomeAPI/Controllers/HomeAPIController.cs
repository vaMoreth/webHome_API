using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webHome_HomeAPI.Data;
using webHome_HomeAPI.Logging;
using webHome_HomeAPI.Models;
using webHome_HomeAPI.Models.Dto;

namespace webHome_HomeAPI.Controllers
{
    [Route("api/HomeAPI")]
    [ApiController]
    public class HomeAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public HomeAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        #region CustomLogger
        //private readonly ILogging _logger;

        //public HomeAPIController(ILogging logger)
        //{
        //    _logger = logger;
        //}
        #endregion

        #region BasicLogger
        //private readonly ILogger<HomeAPIController> _logger;

        //public HomeAPIController(ILogger<HomeAPIController> logger)
        //{
        //    _logger = logger;
        //}
        #endregion

        #region GetAll
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<HomeDTO>> GetHomes()
        {
            //_logger.LogInformation("Getting All Homes");
            return Ok(_db.Homes.ToList());
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
            {
                //_logger.LogError("Get home error with Id: " + id);
                return BadRequest();
            }

            var home = _db.Homes.FirstOrDefault(u => u.Id == id);

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
        public ActionResult<HomeDTO> CreateHome([FromBody] HomeDTO homeDTO)
        {
            #region Validators

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            if (_db.Homes.FirstOrDefault(u => u.Name.ToLower() == homeDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Home name already Exists!");
                return BadRequest(ModelState);
            }

            if (homeDTO == null)
                return BadRequest();

            if (homeDTO.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            #endregion

            Home model = new()
            {
                Amenity = homeDTO.Amenity,
                Details = homeDTO.Details,
                Id = homeDTO.Id,
                ImageUrl = homeDTO.ImageUrl,
                Name = homeDTO.Name,
                Occupancy = homeDTO.Occupancy,
                Rate = homeDTO.Rate,
                Sqft = homeDTO.Sqft
            };

            _db.Homes.Add(model);
            _db.SaveChanges();

            //homeDTO.Id = HomeStore.homeList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            //HomeStore.homeList.Add(homeDTO);

            return CreatedAtRoute("GetHome", new { id = homeDTO.Id }, homeDTO);
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

            var home = _db.Homes.FirstOrDefault(u => u.Id == id);

            if (home == null)
                return NotFound();

            _db.Homes.Remove(home);
            _db.SaveChanges();
            return NoContent();
        }
        #endregion

        #region Put
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("id", Name = "UpdateHome")]
        public IActionResult UpdateHome(int id, [FromBody] HomeDTO homeDTO)
        {
            if(homeDTO == null || id != homeDTO.Id)
                return BadRequest();

            //var home = HomeStore.homeList.FirstOrDefault(u => u.Id == id);

            //home.Name = homeDTO.Name;
            //home.Occupancy = homeDTO.Occupancy;
            //home.Sqft = homeDTO.Sqft;

            Home model = new()
            {
                Amenity = homeDTO.Amenity,
                Details = homeDTO.Details,
                Id = homeDTO.Id,
                ImageUrl = homeDTO.ImageUrl,
                Name = homeDTO.Name,
                Occupancy = homeDTO.Occupancy,
                Rate = homeDTO.Rate,
                Sqft = homeDTO.Sqft
            };

            _db.Homes.Update(model);
            _db.SaveChanges();

            return NoContent();
        }
        #endregion

        #region Patch
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("id", Name = "UpdatePartialHome")]
        public IActionResult UpdatePartialHome(int id, JsonPatchDocument<HomeDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
                return BadRequest();

            var home = _db.Homes.AsNoTracking().FirstOrDefault(u => u.Id == id);

            HomeDTO homeDTO = new()
            {
                Amenity = home.Amenity,
                Details = home.Details,
                Id = home.Id,
                ImageUrl = home.ImageUrl,
                Name = home.Name,
                Occupancy = home.Occupancy,
                Rate = home.Rate,
                Sqft = home.Sqft
            };

            if (home == null)
                return BadRequest();

            patchDTO.ApplyTo(homeDTO, ModelState);

            Home model = new Home()
            {
                Amenity = homeDTO.Amenity,
                Details = homeDTO.Details,
                Id = homeDTO.Id,
                ImageUrl = homeDTO.ImageUrl,
                Name = homeDTO.Name,
                Occupancy = homeDTO.Occupancy,
                Rate = homeDTO.Rate,
                Sqft = homeDTO.Sqft
            };

            _db.Homes.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return NoContent();

        }
        #endregion
    }
}
