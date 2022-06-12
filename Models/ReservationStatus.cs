namespace ath_hostels.Models
{
    public class ReservationStatus
    {
        public int ReservationStatusId { get; set; }
        public bool Activation { get; set; }
        public decimal Payment { get; set; }
        public bool Terminated { get; set; }
    }
}
