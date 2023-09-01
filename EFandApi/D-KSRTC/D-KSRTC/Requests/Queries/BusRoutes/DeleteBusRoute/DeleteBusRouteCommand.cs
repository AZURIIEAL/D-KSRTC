using MediatR;

namespace D_KSRTC.Requests.Queries.BusRoutes.DeleteBusRoute
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
