using Microsoft.EntityFrameworkCore;
using Staycation.Api.Data.Models;

namespace Staycation.Api.Data.Access
{
    public class AccommodationContext:DbContext
    {
        public AccommodationContext(DbContextOptions options):base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accommodation>().Property(a => a.FreeCancelation).HasDefaultValue(true);
        }

        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
