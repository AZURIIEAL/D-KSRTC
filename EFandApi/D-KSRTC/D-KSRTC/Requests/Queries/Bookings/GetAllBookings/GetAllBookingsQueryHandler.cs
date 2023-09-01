using D_KSRTC.Models;
using D_KSRTC.Repositories.Bookings;
using MediatR;

namespace D_KSRTC.Requests.Queries.Bookings.GetAllBookings
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<Booking>>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetAllBookingsQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<List<Booking>> Handle(GetAllBookingsQuery query, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetAllBookingsAsync();
        }
    }
}
