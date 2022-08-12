using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Data.Services;
using Staycation.Api.Data.ViewModels;

namespace Staycation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        public ReservationsService _reservationsService;
        public ReservationsController(ReservationsService reservationsService)
        {
            _reservationsService = reservationsService;
        }

        [HttpPost]
        public IActionResult AddReservationForAccommodation([FromBody]ReservationVM reservationVM)
        {
            try
            {
                var newReservation = _reservationsService.AddReservationForAccommodation(reservationVM);
                return Created(nameof(AddReservationForAccommodation), newReservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            try
            {
                var allReservations = _reservationsService.GetAllReservations();
                return Ok(allReservations);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservationById(int id, [FromBody] ReservationVM reservationVM)
        {
            try
            {
                var updatedReservation = _reservationsService.UpdateReservationById(id, reservationVM);
                return Ok(updatedReservation);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservationById(int id)
        {
            try
            {
                _reservationsService.DeleteReservationById(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}