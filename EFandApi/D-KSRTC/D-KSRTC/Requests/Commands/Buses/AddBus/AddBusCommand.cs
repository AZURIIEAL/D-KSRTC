using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Buses.AddBus
{
    public class AddBusCommand : IRequest<Bus>
    {
        public string BusName { get; set; } = string.Empty;
        public int TCId { get; set; }
        public int TotalSeats { get; set; }
    }
}
