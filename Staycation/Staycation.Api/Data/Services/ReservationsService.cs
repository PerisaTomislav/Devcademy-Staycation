using Staycation.Api.Data.Access;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.ViewModels;

namespace Staycation.Api.Data.Services
{
    public class ReservationsService
    {
        private AccommodationContext _context;

        public ReservationsService(AccommodationContext context)
        {
            _context = context;
        }

        public ReservationVM AddReservationForAccommodation(ReservationVM reservationVM)
        {
            var accommodation = _context.Accommodations.FirstOrDefault(a => a.Id == reservationVM.AccommodationId);
            if (accommodation != null)
            {
                var _reservation = new Reservation()
                {
                    Email = reservationVM.Email,
                    CheckIn = reservationVM.CheckIn,
                    CheckOut = reservationVM.CheckOut,
                    PersonCount = reservationVM.PersonCount,
                    Confirmed = reservationVM.Confirmed,
                    AccommodationId = reservationVM.AccommodationId
                };
                _context.Reservations.Add(_reservation);
                _context.SaveChanges();
                return reservationVM;
            }
            else
            {
                throw new Exception($"The accommodation with id: {reservationVM.AccommodationId} does not exist!");
            }
        }

        public List<Reservation> GetAllReservations()
        {
            var allReservations = _context.Reservations.ToList();
            return allReservations;
        }

        public Reservation UpdateReservationById(int id, ReservationVM reservationVM)
        {
            var _reservation = _context.Reservations.FirstOrDefault(n => n.Id == id);
            if (_reservation != null)
            {
                if (_reservation.AccommodationId != reservationVM.AccommodationId)
                {
                    var accommodation = _context.Accommodations.FirstOrDefault(a => a.Id == reservationVM.AccommodationId);
                    if (accommodation != null)
                    {
                        _reservation.AccommodationId = reservationVM.AccommodationId;
                    }
                    else
                    {
                        throw new Exception($"Accommodation with id: {reservationVM.AccommodationId} does not exist");
                    }
                }
                _reservation.Email = reservationVM.Email;
                _reservation.CheckIn = reservationVM.CheckIn;
                _reservation.CheckOut = reservationVM.CheckOut;
                _reservation.PersonCount = reservationVM.PersonCount;
                _reservation.Confirmed = reservationVM.Confirmed;
                _context.SaveChanges();
                return _reservation;
            }
            else
            {
                throw new Exception($"Reservation with id: {id} does not exist!");
            }
        }

        public void DeleteReservationById(int id)
        {
            var _reservation = _context.Reservations.FirstOrDefault(n => n.Id == id);
            if (_reservation != null)
            {
                _context.Remove(_reservation);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"Reservation with id: {id} does not exist!");
            }
        }
    }
}
