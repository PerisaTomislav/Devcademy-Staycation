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
        private readonly ILogger<LocationsController> _logger;
        public LocationsController(LocationsService locationsService, ILogger<LocationsController> logger)
        {
            _locationsService = locationsService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddLocation([FromBody] LocationVM locationVM)
        {
            try
            {
                _logger.LogInformation("Executing AddLocation");
                var newLocation=_locationsService.AddLocation(locationVM);
                _logger.LogInformation("Successfully added location");
                return Created(nameof(AddLocation),newLocation);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error occured while trying to add new location");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            try
            {
                _logger.LogInformation("Executing GetAllLocations");
                var allLocations = _locationsService.GetAllLocations();
                _logger.LogInformation("Successfully retrieved all locations");
                return Ok(allLocations);
            }
            catch (Exception)
            {
                _logger.LogInformation("Error occured while trying to retrieve all locations");
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLocationById(int id, [FromBody] LocationVM locationVM)
        {
            try
            {
                _logger.LogInformation("Executing UpdateLocationById");
                var updatedLocation = _locationsService.UpdateLocationById(id, locationVM);
                _logger.LogInformation($"Successfully updated location with id: {id}");
                return Ok(updatedLocation);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error occured while trying to update location with id: {id}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLocationById(int id)
        {
            try
            {
                _logger.LogInformation("Executing DeleteLocationById");
                _locationsService.DeleteLocationById(id);
                _logger.LogInformation($"Successfully deleted location with id: {id}");
                return Ok();
            }
            catch (Exception)
            {
                _logger.LogInformation($"Error occured while trying to delete location with id: {id}");
                return BadRequest();
            }
        }
    }
}
