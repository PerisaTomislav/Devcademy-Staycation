using Staycation.Api.Data.Models;

namespace Staycation.Api.Data.ViewModels
{
    public class AccommodationVM
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Categorization { get; set; }
        public int PersonCount { get; set; }
        public string ImageUrl { get; set; }
        public bool? FreeCancelation { get; set; }
        public decimal Price { get; set; }
        public string LocationName { get; set; }
        public string PostalCode { get; set; }
    }
}