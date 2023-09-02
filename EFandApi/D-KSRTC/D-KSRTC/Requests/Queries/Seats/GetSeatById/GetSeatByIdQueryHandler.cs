using D_KSRTC.Models;
using D_KSRTC.Repositories.Seats;
using MediatR;

namespace D_KSRTC.Requests.Queries.Seats.GetSeatById
{
    public class GetSeatByIdQueryHandler : IRequestHandler<GetSeatByIdQuery, Seat>
    {
        private readonly ISeatRepository _seatRepository;

        public GetSeatByIdQueryHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public async Task<Seat> Handle(GetSeatByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _seatRepository.GetSeatByIdAsync(request.SeatID);
            return res ?? new Seat();
        }
    }
}
