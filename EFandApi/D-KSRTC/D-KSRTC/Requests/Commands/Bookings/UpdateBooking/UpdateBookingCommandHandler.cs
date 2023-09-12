using D_KSRTC.Repositories.Bookings;
using MediatR;

namespace D_KSRTC.Requests.Commands.Bookings.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, int>
    {
        private readonly IBookingRepository _bookingRepository;

        public UpdateBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<int> Handle(UpdateBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(command.BookingId);
            if (booking == null)
            {
                return default;
            }

            booking.UserId = command.UserId;
            booking.BusRouteId = command.BusRouteId;
            booking.BookingDate = command.BookingDate;
            booking.JourneyDate = command.JourneyDate;
            booking.TotalAmount = command.TotalAmount;

            return 1;
        }
    }
}

