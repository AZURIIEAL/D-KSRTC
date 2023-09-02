using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Seats.GetAllSeats
{
    public class GetAllSeatsQuery : IRequest<List<Seat>>
    {
    }
}
