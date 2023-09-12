using D_KSRTC.Models;
using D_KSRTC.Repositories.Seats;
using MediatR;

namespace D_KSRTC.Requests.Queries.Seats.GetSeatAvailability
{
    public class GetSeatAvailabilityQueryHandler : IRequestHandler<GetSeatAvailabilityQuery, List<Seat>>
    {
        private readonly ISeatRepository _seatRepository;

        public GetSeatAvailabilityQueryHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }
        public async Task<List<Seat>> Handle(GetSeatAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var res = await _seatRepository.GetSeatAvailability(request.BusId,request.Date);
            return res ?? null;
        }
    }
}
