using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Data.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        public int PostalCode { get; set; }

        //Navigation Properties
        public List<Accommodation> Accommodations { get; set; }
    }
}
