using System.ComponentModel.DataAnnotations;

namespace ath_hostels.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string User { get; set; }
        public string Room { get; set; }
    }
}
