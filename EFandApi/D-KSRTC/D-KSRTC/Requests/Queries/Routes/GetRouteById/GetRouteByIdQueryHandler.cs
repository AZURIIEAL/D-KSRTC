using D_KSRTC.Repositories.Routes;
using MediatR;

namespace D_KSRTC.Requests.Queries.Routes.GetRouteById
{
    public class GetRouteByIdQueryHandler : IRequestHandler<GetRouteByIdQuery, Models.Route>
    {
        private readonly IRouteRepository _routeRepository;

        public GetRouteByIdQueryHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<Models.Route> Handle(GetRouteByIdQuery request, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetRouteByIdAsync(request.RouteId);
            return route ?? new Models.Route();
        }
    }
}
