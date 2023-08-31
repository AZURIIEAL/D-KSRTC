using MediatR;

namespace D_KSRTC.Requests.Commands.Buses.UpdateBus
{
    public class UpdateBusCommand : IRequest<int>
    {
        public int BusId { get; set; }
        public string BusName { get; set; } = string.Empty;
        public int TCId { get; set; }
        public int TotalSeats { get; set; }
    }
}
