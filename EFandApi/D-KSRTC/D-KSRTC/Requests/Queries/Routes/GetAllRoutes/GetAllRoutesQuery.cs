using MediatR;

namespace D_KSRTC.Requests.Queries.Routes.GetAllRoutes
{
    public class GetAllRoutesQuery : IRequest<List<Models.Route>>
    {
    }
}
