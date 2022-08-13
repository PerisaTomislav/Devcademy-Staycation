using Microsoft.EntityFrameworkCore;
using Staycation.Api.Data.Access;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.Services;
using Staycation.Api.Data.ViewModels;

namespace Accommodations_tests
{
    public class LocationsServiceTests
    {
        private static DbContextOptions<AccommodationContext> dbContextOptions= new DbContextOptionsBuilder<AccommodationContext>().UseInMemoryDatabase(databaseName:"AccommodationDbTest").Options;

        AccommodationContext context;
        LocationsService locationsService;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AccommodationContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();

            locationsService = new LocationsService(context);
        }

        [Test, Order(1)]
        public void GetAllLocations()
        {
            var result = locationsService.GetAllLocations();
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test, Order(2)]
        public void AddLocation()
        {
            var newLocation = new LocationVM()
            {
                ImageUrl="image url",
                PostalCode="100000",
                Name = "Grad"
            };

            var result = locationsService.AddLocation(newLocation);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.ImageUrl, Is.EqualTo("image url"));
            Assert.That(result.PostalCode,Is.EqualTo("100000"));
            Assert.That(result.Name, Is.EqualTo("Grad"));
        }

        [Test,Order(3)]
        public void DeleteLocation()
        {
            var newLocation = new LocationVM()
            {
                ImageUrl = "image url",
                PostalCode = "42000",
                Name = "Varaždin"
            };
            int newLocationId=locationsService.AddLocation(newLocation).Id;
            locationsService.DeleteLocationById(newLocationId);
            var deletedLocation = context.Locations.Where(a => a.Id == newLocationId).SingleOrDefault();
            Assert.That(deletedLocation, Is.Null);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
                context.Locations.Add(new Location()
                {
                    Id = 1,
                    ImageUrl = "image path 1",
                    PostalCode = "33000",
                    Name = "Virovitica"
                });

            context.SaveChanges();
        }
    }
}