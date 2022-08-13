using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Data.Services;
using Staycation.Api.Data.ViewModels;

namespace Staycation.Api.Controllers
{
    [Route("api/location")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        public LocationsService _locationsService;
        public LocationsController(LocationsService locationsService)
        {
            _locationsService = locationsService;
        }

        [HttpPost]
        public IActionResult AddLocation([FromBody] LocationVM locationVM)
        {
            try
            {
                var newLocation=_locationsService.AddLocation(locationVM);
                return Created(nameof(AddLocation),newLocation);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            try
            {
                var allLocations = _locationsService.GetAllLocations();
                return Ok(allLocations);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLocationById(int id, [FromBody] LocationVM locationVM)
        {
            try
            {
                var updatedLocation = _locationsService.UpdateLocationById(id, locationVM);
                return Ok(updatedLocation);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLocationById(int id)
        {
            try
            {
                _locationsService.DeleteLocationById(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
