
using D_KSRTC.Models;
using MediatR;

public class AddRouteDetailsCommandHandler : IRequestHandler<AddRouteDetailsCommand, RouteDetails>
{
    private readonly IRouteDetailsRepository _routeDetailsRepository;

    public AddRouteDetailsCommandHandler(IRouteDetailsRepository routeDetailsRepository)
    {
        _routeDetailsRepository = routeDetailsRepository;
    }

    public async Task<RouteDetails> Handle(AddRouteDetailsCommand command, CancellationToken cancellationToken)
    {
        var routeDetails = new RouteDetails
        {
            RouteId = command.RouteId,
            StopId = command.StopId,
            Sequence = command.Sequence,
            Distance = command.Distance,
            Duration = command.Duration
        };

        return await _routeDetailsRepository.AddRouteDetailsAsync(routeDetails);
    }
}
