using MediatR;

namespace D_KSRTC.Requests.Commands.BusRoutes.DeleteBusRoute
{
    public class DeleteBusRouteCommand : IRequest<int>
    {
        public int BusRouteId { get; set; }

        public DeleteBusRouteCommand(int busRouteId)
        {
            BusRouteId = busRouteId;
        }
    }
}
