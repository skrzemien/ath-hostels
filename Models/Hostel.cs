namespace ath_hostels.Models
{
    public class Hostel
    {
        public int HostelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

        ICollection<Room> Rooms { get; set; }
    }
}
