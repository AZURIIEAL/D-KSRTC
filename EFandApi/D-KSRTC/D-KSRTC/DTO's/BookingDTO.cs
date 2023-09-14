namespace D_KSRTC.DTO_s
{
    public class BookingDTO
    {
        public int UserId { get; set; }
        public int BusRouteId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime JourneyDate { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
