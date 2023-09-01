using D_KSRTC.Repositories.Routes;
using MediatR;

namespace D_KSRTC.Requests.Queries.Routes.GetAllRoutes
{
    public class GetAllRoutesQueryHandler : IRequestHandler<GetAllRoutesQuery, List<Models.Route>>
    {
        private readonly IRouteRepository _routeRepository;

        public GetAllRoutesQueryHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<List<Models.Route>> Handle(GetAllRoutesQuery query, CancellationToken cancellationToken)
        {
            return await _routeRepository.GetAllRoutesAsync();
        }
    }
}
