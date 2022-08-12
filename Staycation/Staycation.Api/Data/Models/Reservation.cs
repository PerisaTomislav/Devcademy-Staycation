using System.ComponentModel.DataAnnotations;
namespace Staycation.Api.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PersonCount { get; set; }

        [Required]
        public bool Confirmed { get; set; }

        //Navigation properties
        public int AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }
    }
}