using D_KSRTC.Repositories.Bookings;
using MediatR;

namespace D_KSRTC.Requests.Commands.Bookings.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, int>
    {
        private readonly IBookingRepository _bookingRepository;

        public DeleteBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<int> Handle(DeleteBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.DeleteBookingAsync(command.BookingId);
            if (booking == null)
            {
                return default;
            }

            return 1;
        }
    }
}
