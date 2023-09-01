using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypes.DeleteBusType
{
    public class DeleteBusTypeCommand : IRequest<int>
    {
        public int TypeId { get; set; }
    }
}
