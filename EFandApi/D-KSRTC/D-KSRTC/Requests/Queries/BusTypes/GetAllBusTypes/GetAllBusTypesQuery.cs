using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusTypes.GetAllBusTypes
{
    public class GetAllBusTypesQuery : IRequest<List<BusType>>
    {
    }
}
