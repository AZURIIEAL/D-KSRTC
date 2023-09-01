using MediatR;

namespace D_KSRTC.Requests.Commands.Routes.DeleteRoute
{
    public class DeleteRouteCommand : IRequest<int>
    {
        public int RouteId { get; set; }
    }

}
