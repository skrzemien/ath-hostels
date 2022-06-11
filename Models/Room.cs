namespace ath_hostels.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HostelId {get; set; }
        public decimal Price { get; set; }
        public int Beds { get; set; }
    }
}
