using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Bookings.CreateBooking
{
    public class CreateBookingCommand : IRequest<Booking>
    {
        public int UserId { get; set; }
        public int BusRouteId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime JourneyDate { get; set; }
        public float TotalAmount { get; set; }

        public CreateBookingCommand()
        {
            
        }
    }
}
