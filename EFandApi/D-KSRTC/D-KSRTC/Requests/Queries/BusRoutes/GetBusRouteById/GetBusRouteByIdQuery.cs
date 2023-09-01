using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusRoutes.GetBusRouteById
{
    public class GetBusRouteByIdQuery : IRequest<BusRoute>
    {
        public int BusRouteId { get; set; }

        public GetBusRouteByIdQuery(int busRouteId)
        {
            BusRouteId = busRouteId;
        }
    }
}
