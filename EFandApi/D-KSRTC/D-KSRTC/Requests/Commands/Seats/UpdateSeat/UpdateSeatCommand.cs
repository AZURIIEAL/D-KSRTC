using MediatR;

namespace D_KSRTC.Requests.Commands.Seats.UpdateSeat
{
    public class UpdateSeatCommand : IRequest<int>
    {
        public int SeatID { get; set; }
        public int BusID { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public string Availability { get; set; } = string.Empty;
    }
}
