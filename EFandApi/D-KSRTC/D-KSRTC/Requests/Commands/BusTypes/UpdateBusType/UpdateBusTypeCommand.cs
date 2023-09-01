using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypes.UpdateBusType
{
    public class UpdateBusTypeCommand : IRequest<int>
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public float PDF { get; set; }
    }
}
