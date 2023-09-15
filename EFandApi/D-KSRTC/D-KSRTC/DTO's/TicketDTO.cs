

namespace D_KSRTC.DTO_s
{
    public class TicketDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string BusRouteName { get; set; } = string.Empty;
        public DateTime JourneyDate { get; set; }
        public DateTime BusTime { get; set; }
        public int PassengerId { get; set; }
        public string BusName { get; set; } = string.Empty;
        public string Seat { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string FromLocation { get; set; } = string.Empty;
        public string ToLocation { get; set; } = string.Empty;
    }
}
