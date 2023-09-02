using D_KSRTC.Repositories.Seats;
using MediatR;

namespace D_KSRTC.Requests.Commands.Seats.DeleteSeat
{
    public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, int>
    {
        private readonly ISeatRepository _seatRepository;

        public DeleteSeatCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<int> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
        {
            return await _seatRepository.DeleteSeatAsync(request.SeatID);
        }
    }
}
