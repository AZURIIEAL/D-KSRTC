using D_KSRTC.Models;
using D_KSRTC.Repositories.Seats;
using MediatR;

namespace D_KSRTC.Requests.Commands.Seats.PatchSeatAvailability
{
    public class PatchSeatAvailabilityCommandHandler : IRequestHandler<PatchSeatAvailabilityCommand, int>
    {
        private readonly ISeatRepository _seatRepository;

        public PatchSeatAvailabilityCommandHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<int> Handle(PatchSeatAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var res = await _seatRepository.GetSeatByIdAsync(request.SeatID);

            res.UpdateSeatAvailabltity(request.Availability);
            return await _seatRepository.UpdateSeatAsync(res);

        }
    }
}

