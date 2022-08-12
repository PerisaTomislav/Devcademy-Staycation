using System.ComponentModel.DataAnnotations;
    
namespace Staycation.Api.Data.ViewModels
{
    public class ReservationVM
    {
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

        [Required]
        public int AccommodationId { get; set; }
    }
}
