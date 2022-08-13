using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Staycation.Api.Controllers;
using Staycation.Api.Data.Access;
using Staycation.Api.Data.Models;
using Staycation.Api.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accommodations_tests
{
    internal class LocationsControllerTests
    {
        private static DbContextOptions<AccommodationContext> dbContextOptions = new DbContextOptionsBuilder<AccommodationContext>().UseInMemoryDatabase(databaseName: "AccommodationDbControllerTest").Options;

        AccommodationContext context;
        LocationsService locationsService;
        LocationsController locationsController;

        [OneTimeSetUp]
        public void Setup()
        {
            context = new AccommodationContext(dbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();

            locationsService = new LocationsService(context);
            locationsController = new LocationsController(locationsService, new NullLogger<LocationsController>());
        }

        [Test]
        public void HTTPGET_GetAllLocations_ReturnOk()
        {
            IActionResult actionResult = locationsController.GetAllLocations();
            Assert.That(actionResult, Is.TypeOf<OkObjectResult>());
            var actionResultData = (actionResult as OkObjectResult).Value as List<Location>;
            Assert.That(actionResultData.First().PostalCode, Is.EqualTo("33000"));
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
