using Staycation.Api.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Data.ViewModels
{
    public class AccommodationVM
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string? Subtitle { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }

        [Required]
        public int Categorization { get; set; }

        [Required]
        public int PersonCount { get; set; }

        [MaxLength(800)]
        public string? ImageUrl { get; set; }
        public bool? FreeCancelation { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string LocationName { get; set; }

        [Required]
        public string PostalCode { get; set; }
    }
}