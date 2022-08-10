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
                Name = locationVM.Name,
                PostalCode = locationVM.PostalCode
            };
            _context.Locations.Add(_location);
            _context.SaveChanges();
            return _location;
        }
    }
}
