using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusTypes.GetBusTypeById
{
    public class GetBusTypeByIdQuery : IRequest<BusType>
    {
        public int TypeId { get; set; }
    }
}
