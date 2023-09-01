using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Bookings.GetBookingById
{
    public class GetBookingByIdQuery : IRequest<Booking>
    {
        public int BookingId { get; set; }
    }
}
