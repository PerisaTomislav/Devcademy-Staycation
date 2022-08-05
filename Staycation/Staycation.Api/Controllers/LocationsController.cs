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
                _locationsService.AddLocation(locationVM);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
