using MediatR;

namespace D_KSRTC.Requests.Commands.BusRoutes.UpdateBusRoute
{
    public class UpdateBusRouteCommand : IRequest<int>
    {
        public int BusRouteId { get; set; }
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public int TimeId { get; set; }

        public DateTime RouteDate { get; set; }

        public UpdateBusRouteCommand(int busRouteId, int busId, int routeId, int timeId, DateTime routeDate)
        {
            BusRouteId = busRouteId;
            BusId = busId;
            RouteId = routeId;
            TimeId = timeId;
            RouteDate = routeDate;

        }
    }
}
