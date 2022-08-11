using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Data.Models
{
    public class Location
    {
        public int Id { get; set; }

        [MaxLength(800)]
        public string ImageUrl { get; set; }
        public int PostalCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        

        //Navigation Properties
        public List<Accommodation> Accommodations { get; set; }
    }
}
