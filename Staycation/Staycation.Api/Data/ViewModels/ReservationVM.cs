namespace Staycation.Api.Data.ViewModels
{
    public class ReservationVM
    {
        public string Email { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int PersonCount { get; set; }
        public bool Confirmed { get; set; }
    }
}
