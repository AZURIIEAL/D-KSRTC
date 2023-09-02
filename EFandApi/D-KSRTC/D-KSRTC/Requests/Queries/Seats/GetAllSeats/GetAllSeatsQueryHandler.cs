using D_KSRTC.Models;
using D_KSRTC.Repositories.Seats;
using MediatR;

namespace D_KSRTC.Requests.Queries.Seats.GetAllSeats
{
    public class GetAllSeatsQueryHandler : IRequestHandler<GetAllSeatsQuery, List<Seat>>
    {
        private readonly ISeatRepository _seatRepository;

        public GetAllSeatsQueryHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<List<Seat>> Handle(GetAllSeatsQuery request, CancellationToken cancellationToken)
        {
            return await _seatRepository.GetAllSeatsAsync();
        }
    }
}
