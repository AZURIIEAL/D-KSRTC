using MediatR;

namespace D_KSRTC.Requests.Commands.Seats.PatchSeatAvailability
{
    public class PatchSeatAvailabilityCommand : IRequest<int>
    {
        public int SeatID { get; set; }
        public string Availability { get; set; } = string.Empty;
        public PatchSeatAvailabilityCommand()
        {

        }
 
    }
}
