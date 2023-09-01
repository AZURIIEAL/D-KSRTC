using MediatR;

namespace D_KSRTC.Requests.Commands.RouteDetails.UpdateRouteDetails
{
    public class UpdateRouteDetailsCommandHandler : IRequestHandler<UpdateRouteDetailsCommand, int>
    {
        private readonly IRouteDetailsRepository _routeDetailsRepository;

        public UpdateRouteDetailsCommandHandler(IRouteDetailsRepository routeDetailsRepository)
        {
            _routeDetailsRepository = routeDetailsRepository;
        }

        public async Task<int> Handle(UpdateRouteDetailsCommand command, CancellationToken cancellationToken)
        {
            var routeDetails = await _routeDetailsRepository.GetRouteDetailsByIdAsync(command.RDId);
            if (routeDetails == null)
            {
                return default;
            }

            routeDetails.RouteId = command.RouteId;
            routeDetails.StopId = command.StopId;
            routeDetails.Sequence = command.Sequence;
            routeDetails.Distance = command.Distance;
            routeDetails.Duration = command.Duration;

            return 1;
        }
    }
}
