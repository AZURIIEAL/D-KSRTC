using D_KSRTC.Models;
using D_KSRTC.Repositories.Seats;
using MediatR;

namespace D_KSRTC.Requests.Commands.Seats.AddSeat
{
    public class AddSeatCommandHandler : IRequestHandler<AddSeatCommand, Seat>
    {
        private readonly ISeatRepository _seatRepository;

        public AddSeatCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Seat> Handle(AddSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = new Seat
            {
                BusID = request.BusID,
                SeatNumber = request.SeatNumber,
                Availability = request.Availability
            };

            return await _seatRepository.AddSeatAsync(seat);
        }
    }
}
