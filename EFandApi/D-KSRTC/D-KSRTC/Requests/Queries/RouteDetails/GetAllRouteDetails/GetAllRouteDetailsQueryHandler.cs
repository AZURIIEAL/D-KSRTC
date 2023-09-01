using D_KSRTC.Models;
using MediatR;

public class GetAllRouteDetailsQueryHandler : IRequestHandler<GetAllRouteDetailsQuery, List<RouteDetails>>
{
    private readonly IRouteDetailsRepository _routeDetailsRepository;

    public GetAllRouteDetailsQueryHandler(IRouteDetailsRepository routeDetailsRepository)
    {
        _routeDetailsRepository = routeDetailsRepository;
    }

    public async Task<List<RouteDetails>> Handle(GetAllRouteDetailsQuery query, CancellationToken cancellationToken)
    {
        return await _routeDetailsRepository.GetAllRouteDetailsAsync();
    }
}

