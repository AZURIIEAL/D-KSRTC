using MediatR;

namespace D_KSRTC.Requests.Commands.Buses.DeleteBus
{
    public class DeleteBusCommand : IRequest<int>
    {
        public int BusId { get; set; }
    }
}
