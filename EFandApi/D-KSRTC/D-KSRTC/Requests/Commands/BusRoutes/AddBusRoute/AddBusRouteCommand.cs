using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusRoutes.AddBusRouteCommand
{
    public class AddBusRouteCommand : IRequest<BusRoute>
    {
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public int TimeId { get; set; }

        public AddBusRouteCommand(int busId, int routeId, int timeId)
        {
            BusId = busId;
            RouteId = routeId;
            TimeId = timeId;
        }
    }
}
