using Staycation.Api.Data.Access;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.ViewModels;

namespace Staycation.Api.Data.Services
{
    public class LocationsService
    {
        private AccommodationContext _context;

        public LocationsService(AccommodationContext context)
        {
            _context = context;
        }

        public Location AddLocation(LocationVM locationVM)
        {
            var _location = new Location()
            {
                ImageUrl = locationVM.ImageUrl,
                Name = locationVM.Name,
                PostalCode = locationVM.PostalCode
            };
            _context.Locations.Add(_location);
            _context.SaveChanges();
            return _location;
        }

        public List<Location> GetLocations()
        {
            var allLocations = _context.Locations.ToList();
            return allLocations;
        }

        public Location UpdateLocationById(int id, LocationVM locationVM)
        {
            var _location = _context.Locations.FirstOrDefault(n => n.Id == id);
            if (_location != null)
            {
                _location.ImageUrl = locationVM.ImageUrl;
                _location.Name = locationVM.Name;
                _location.PostalCode = locationVM.PostalCode;

                _context.SaveChanges();
            }
            return _location;
        }

        public void DeleteLocationById(int id)
        {
            var _location = _context.Locations.FirstOrDefault(n => n.Id == id);
            if (_location != null)
            {
                _context.Remove(_location);
                _context.SaveChanges();
            }
        }
    }
}