using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Data.Services;
using Staycation.Api.Data.ViewModels;

namespace Staycation.Api.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        public ReservationsService _reservationsService;
        private readonly ILogger<ReservationsController> _logger;
        public ReservationsController(ReservationsService reservationsService, ILogger<ReservationsController> logger)
        {
            _reservationsService = reservationsService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddReservationForAccommodation([FromBody]ReservationVM reservationVM)
        {
            try
            {
                _logger.LogInformation("Executing AddReservationForAccommodation");
                var newReservation = _reservationsService.AddReservationForAccommodation(reservationVM);
                _logger.LogInformation($"Successfully added reservation for accommodation with id: {reservationVM.AccommodationId}");
                return Created(nameof(AddReservationForAccommodation), newReservation);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error occured while trying to add reservation for accommodation with id: {reservationVM.AccommodationId}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            try
            {
                _logger.LogInformation("Executing GetAllReservations");
                var allReservations = _reservationsService.GetAllReservations();
                _logger.LogInformation("Successfully retrieved all reservations");
                return Ok(allReservations);
            }
            catch (Exception)
            {
                _logger.LogInformation("Error occured while trying to retrieve all reservations");
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservationById(int id, [FromBody] ReservationVM reservationVM)
        {
            try
            {
                _logger.LogInformation("Executing UpdateReservationById");
                var updatedReservation = _reservationsService.UpdateReservationById(id, reservationVM);
                _logger.LogInformation($"Successfully updated reservation with id: {id}");
                return Accepted(updatedReservation);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Error occured while trying to update reservation with id: {id}");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservationById(int id)
        {
            try
            {
                _logger.LogInformation("Executing DeleteReservationById");
                _reservationsService.DeleteReservationById(id);
                _logger.LogInformation($"Successfully deleted reservation with id: {id}");
                return Ok();
            }
            catch (Exception)
            {
                _logger.LogInformation($"Error occured while trying to delete reservation with id: {id}");
                return BadRequest();
            }
        }
    }
}