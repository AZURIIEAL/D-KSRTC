using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusRoutes.AddBusRouteCommand
{
    public class AddBusRouteCommand : IRequest<BusRoute>
    {
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public DateTime Time { get; set; }

        public DateTime RouteDate { get; set; }

        public AddBusRouteCommand() { }
        public AddBusRouteCommand(int busId, int routeId, DateTime time,DateTime dateTime)
        {
            BusId = busId;
            RouteId = routeId;
            Time = time;
            RouteDate = dateTime;
        }
    }
}
