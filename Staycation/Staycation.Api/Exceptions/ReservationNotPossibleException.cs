namespace Staycation.Api.Exceptions
{
    public class ReservationNotPossibleException:Exception
    {
        public ReservationNotPossibleException():base()
        {

        }
        public ReservationNotPossibleException(string message):base(message)
        {

        }
    }
}
