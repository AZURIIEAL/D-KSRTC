using MediatR;

namespace D_KSRTC.Requests.Commands.Seats.DeleteSeat
{
    public class DeleteSeatCommand : IRequest<int>
    {
        public int SeatID { get; set; }
    }
}
