using MediatR;

namespace D_KSRTC.Requests.Commands.Bookings.DeleteBooking
{
    public class DeleteBookingCommand : IRequest<int>
    {
        public int BookingId { get; set; }
    }
}
