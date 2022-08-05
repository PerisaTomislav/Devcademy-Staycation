using Staycation.Api.Data.Access;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.ViewModels;

namespace Staycation.Api.Data.Services
{
    public class AccommodationsService
    {
        private AccommodationContext _context;
        
        public AccommodationsService(AccommodationContext context)
        {
            _context = context;
        }

        public void AddAccommodationWithLocation(AccommodationVM accommodationVM)
        {
            var _location = _context.Locations.
                Where(a => a.Name == accommodationVM.LocationName).Where(a => a.PostalCode == accommodationVM.PostalCode).SingleOrDefault();

            if (_location == null)
            {
                var newLocation = new Location()
                {
                    Name = accommodationVM.LocationName,
                    PostalCode = accommodationVM.PostalCode
                };
                _context.Locations.Add(newLocation);
                _context.SaveChanges();
            }

            int locationId = _context.Locations.Where(b => b.Name == accommodationVM.LocationName)
    .Where(b => b.PostalCode == accommodationVM.PostalCode).SingleOrDefault()!.Id;

            var _accommodation = new Accommodation()
            {
                Title = accommodationVM.Title,
                Subtitle = accommodationVM.Subtitle,
                Description = accommodationVM.Description,
                Type = accommodationVM.Type,
                Categorization = accommodationVM.Categorization,
                PersonCount = accommodationVM.PersonCount,
                ImageUrl = accommodationVM.ImageUrl,
                FreeCancelation = accommodationVM.FreeCancelation,
                Price = accommodationVM.Price,
                LocationId= locationId,
            };
            _context.Accommodations.Add(_accommodation);
            _context.SaveChanges();
        }

        public List<Accommodation> GetAccommodations()
        {
            var allAccommodations = _context.Accommodations.ToList();
            return allAccommodations;
        }

        public Accommodation UpdateAccommodationById(int id, AccommodationVM accommodationVM)
        {
            var _accommodation = _context.Accommodations.FirstOrDefault(n => n.Id == id);
            if (_accommodation != null)
            {
                _accommodation.Title = accommodationVM.Title;
                _accommodation.Subtitle = accommodationVM.Subtitle;
                _accommodation.Description = accommodationVM.Description;
                _accommodation.Type = accommodationVM.Type;
                _accommodation.Categorization = accommodationVM.Categorization;
                _accommodation.PersonCount = accommodationVM.PersonCount;
                _accommodation.ImageUrl = accommodationVM.ImageUrl;
                _accommodation.FreeCancelation = accommodationVM.FreeCancelation;
                _accommodation.Price = accommodationVM.Price;

                _context.SaveChanges();
            }
            return _accommodation;
        }

        public void DeleteAccommodationById(int id)
        {
            var _accommodation = _context.Accommodations.FirstOrDefault(n => n.Id == id);
            if (_accommodation != null)
            {
                _context.Remove(_accommodation);
                _context.SaveChanges();
            }
        }
    }
}
