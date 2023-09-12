using D_KSRTC.Models;
using D_KSRTC.Repositories.Bookings;
using MediatR;

namespace D_KSRTC.Requests.Commands.Bookings.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Booking>
    {
        private readonly IBookingRepository _bookingRepository;

        public CreateBookingCommandHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> Handle(CreateBookingCommand command, CancellationToken cancellationToken)
        {
            var booking = new Booking()
            {
                UserId = command.UserId,
                BusRouteId = command.BusRouteId,
                BookingDate = command.BookingDate,
                JourneyDate = command.JourneyDate,
                TotalAmount = command.TotalAmount,

            };

            return await _bookingRepository.AddBookingAsync(booking);
        }
    }
}
