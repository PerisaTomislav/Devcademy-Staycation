using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Data.Services;
using Staycation.Api.Data.ViewModels;

namespace Staycation.Api.Controllers
{
    [Route("api/accommodation")]
    [ApiController]
    public class AccommodationsController : ControllerBase
    {
        public AccommodationsService _accommodationsService;
        private readonly ILogger<AccommodationsController> _logger;
        public AccommodationsController(AccommodationsService accommodationsService, ILogger<AccommodationsController> logger)
        {
            _accommodationsService = accommodationsService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddAccommodationWithLocation([FromBody]AccommodationVM accommodationVM)
        {
            try
            {
                _logger.LogInformation("Executing AddAccommodationWithLocation");
                var newAccommodation=_accommodationsService.AddAccommodationWithLocation(accommodationVM);
                _logger.LogInformation("Successfully added accommodation with location");
                return Created(nameof(AddAccommodationWithLocation),newAccommodation);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error occured while trying to execute AddAccommodationWithLocation method");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAccommodations()
        {
            try
            {
                _logger.LogInformation("Executing GetAccommodations");
                var allAccommodations = _accommodationsService.GetAccommodations();
                _logger.LogInformation("Successfully retrieved all accommodations");
                return Ok(allAccommodations);
            }
            catch (Exception)
            {
                _logger.LogInformation("Error occured while trying to execute GetAccommodations method");
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAccommodationById(int id, [FromBody]AccommodationVM accommodationVM)
        {
            try
            {
                _logger.LogInformation("Executing UpdateAccommodationById");
                var updatedAccommodation = _accommodationsService.UpdateAccommodationById(id, accommodationVM);
                _logger.LogInformation($"Successfully updated accommodation with id: {id}");
                return Ok(updatedAccommodation);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error occured while trying to update accommodation with id: {id}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccommodationById(int id)
        {
            try
            {
                _logger.LogInformation("Executing DeleteAccommodationById");
                _accommodationsService.DeleteAccommodationById(id);
                _logger.LogInformation($"Successfully deleted accommodation with id: {id}");
                return Ok();
            }
            catch (Exception)
            {
                _logger.LogInformation($"Error occured while trying to delete accommodation with id: {id}");
                return BadRequest();
            }
        }

        [HttpGet("recommendation")]
        public IActionResult GetAccommodationRecommendations()
        {
            try
            {
                _logger.LogInformation("Executing GetAccommodationRecomendations");
                var accommodationRecomendations = _accommodationsService.GetAccommodationRecommendations();
                _logger.LogInformation("Successfully retrieved accommodation recommendations");
                return Ok(accommodationRecomendations);
            }
            catch (Exception)
            {
                _logger.LogInformation("Error occured while trying to retrieve accommodation recommendations");
                return BadRequest();
            }
        }

        [HttpGet("location/{id}")]
        public IActionResult GetAllLocationsForGivenAccommodationId(int id)
        {
            try
            {
                _logger.LogInformation("Executing GetAllLocationsForGivenAccommodationId");
                var accommodationsOfALocation = _accommodationsService.GetAccommodationsOfALocation(id);
                _logger.LogInformation($"Successfully retrieved locations for accommodation with id: {id}");
                return Ok(accommodationsOfALocation);
            }
            catch (Exception)
            {
                _logger.LogInformation($"Error occured while trying to retrieve locations for accommodation with id: {id}");
                return BadRequest();
            }
        }
    }
}
