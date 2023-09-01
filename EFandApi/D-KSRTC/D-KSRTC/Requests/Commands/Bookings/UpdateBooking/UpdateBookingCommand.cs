using MediatR;

namespace D_KSRTC.Requests.Commands.Bookings.UpdateBooking
{
    public class UpdateBookingCommand : IRequest<int>
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int BusRouteId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime JourneyDate { get; set; }
        public float TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
