using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusRoutes.GetAllBusRoutes
{
    public class GetAllBusRoutesQuery : IRequest<List<BusRoute>>
    {
    }
}
