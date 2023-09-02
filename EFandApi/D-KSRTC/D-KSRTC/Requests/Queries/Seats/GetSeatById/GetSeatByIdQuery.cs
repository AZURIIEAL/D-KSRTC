using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Seats.GetSeatById
{
    public class GetSeatByIdQuery : IRequest<Seat>
    {
        public int SeatID { get; set; }
    }
}
