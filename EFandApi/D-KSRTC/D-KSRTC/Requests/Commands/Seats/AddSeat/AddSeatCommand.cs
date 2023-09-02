using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Seats.AddSeat
{
    public class AddSeatCommand : IRequest<Seat>
    {
        public int BusID { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public string Availability { get; set; } = string.Empty;
    }
}
