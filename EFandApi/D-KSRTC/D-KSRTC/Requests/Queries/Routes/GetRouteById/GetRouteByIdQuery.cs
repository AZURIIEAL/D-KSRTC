using MediatR;

namespace D_KSRTC.Requests.Queries.Routes.GetRouteById
{
    public class GetRouteByIdQuery : IRequest<Models.Route>
    {
        public int RouteId { get; set; }
    }
}
