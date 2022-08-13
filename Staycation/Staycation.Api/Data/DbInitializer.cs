using Staycation.Api.Data.Access;
using Staycation.Api.Data.Models;

namespace Staycation.Api.Data
{
    public class DbInitializer
    {
        public static void SeedDb(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AccommodationContext>();

                if (!context.Locations.Any())
                {
                    context.Locations.Add(new Location()
                    {
                        Id=1,
                        ImageUrl = "image path 1",
                        PostalCode="33000",
                        Name="Virovitica"
                    });
                    context.SaveChanges();
                }

                if (!context.Accommodations.Any())
                {
                    context.Accommodations.Add(new Accommodation()
                    {
                        Id=1,
                        Title = "Studentski dom",
                        Subtitle = "Studentski dom za iznajmljivanje",
                        Description = "Lijep i ugodan dom za studente svih godina",
                        Type = "Dom",
                        Categorization = 5,
                        PersonCount = 20,
                        ImageUrl = "image path",
                        FreeCancelation = false,
                        Price = 600,
                        LocationId = 1
                    });
                }

                if (!context.Reservations.Any())
                {
                    context.Reservations.Add(new Reservation()
                    {
                        Email = "tomislav.pingi.perisa@gmail.com",
                        AccommodationId = 1,
                        CheckIn = DateTime.Now,
                        PersonCount=1,
                        Confirmed=true
                    });
                }
            }

        }
    }
}
