using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Bookings.GetAllBookings
{
    public class GetAllBookingsQuery : IRequest<List<Booking>>
    {
    }
}
