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
        public AccommodationsController(AccommodationsService accommodationsService)
        {
            _accommodationsService = accommodationsService;
        }

        [HttpPost]
        public IActionResult AddAccommodation([FromBody]AccommodationVM accommodationVM)
        {
            try
            {
                _accommodationsService.AddAccommodation(accommodationVM);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAccommodations()
        {
            var allAccommodations=_accommodationsService.GetAccommodations();
            return Ok(allAccommodations);
        }

        [HttpPut("/{id}")]
        public IActionResult UpdateAccommodationById(int id, [FromBody]AccommodationVM accommodationVM)
        {
            try
            {
                var updatedAccommodation = _accommodationsService.UpdateAccommodationById(id, accommodationVM);
                return Ok(updatedAccommodation);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteAccommodationById(int id)
        {
            try
            {
                _accommodationsService.DeleteAccommodationById(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            
        }
    }
}
