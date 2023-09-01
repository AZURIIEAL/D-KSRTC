using D_KSRTC.Models;
using MediatR;



public class GetRouteDetailsByIdQueryHandler : IRequestHandler<GetRouteDetailsByIdQuery, RouteDetails>
{
    private readonly IRouteDetailsRepository _routeDetailsRepository;

    public GetRouteDetailsByIdQueryHandler(IRouteDetailsRepository routeDetailsRepository)
    {
        _routeDetailsRepository = routeDetailsRepository;
    }

    public async Task<RouteDetails> Handle(GetRouteDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var routeDetails = await _routeDetailsRepository.GetRouteDetailsByIdAsync(request.RDId);
        return routeDetails ?? new RouteDetails();
    }
}

