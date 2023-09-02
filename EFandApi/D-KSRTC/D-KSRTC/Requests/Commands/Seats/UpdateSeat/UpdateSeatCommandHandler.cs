using D_KSRTC.Models;
using D_KSRTC.Repositories.Seats;
using MediatR;

namespace D_KSRTC.Requests.Commands.Seats.UpdateSeat
{
    public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, int>
    {
        private readonly ISeatRepository _seatRepository;

        public UpdateSeatCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<int> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
        {
            var seat = new Seat
            {
                SeatID = request.SeatID,
                BusID = request.BusID,
                SeatNumber = request.SeatNumber,
                Availability = request.Availability
            };

            return await _seatRepository.UpdateSeatAsync(seat);
        }
    }
}
