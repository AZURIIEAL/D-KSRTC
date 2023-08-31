using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Buses.GetBusById
{
    public class GetBusByIdQuery : IRequest<Bus>
    {
        public int BusId { get; set; }
    }
}
