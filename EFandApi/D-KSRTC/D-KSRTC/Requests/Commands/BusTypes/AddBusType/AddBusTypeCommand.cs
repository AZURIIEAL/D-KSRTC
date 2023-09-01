using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypes.AddBusType
{
    public class AddBusTypeCommand : IRequest<BusType>
    {
        public string TypeName { get; set; } = string.Empty;
        public float PDF { get; set; }
    }
}
