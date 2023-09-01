using MediatR;

namespace D_KSRTC.Requests.Commands.RouteDetails.DeleteRouteDetails
{
    public class DeleteRouteDetailsCommandHandler : IRequestHandler<DeleteRouteDetailsCommand, int>
    {
        private readonly IRouteDetailsRepository _routeDetailsRepository;

        public DeleteRouteDetailsCommandHandler(IRouteDetailsRepository routeDetailsRepository)
        {
            _routeDetailsRepository = routeDetailsRepository;
        }

        public async Task<int> Handle(DeleteRouteDetailsCommand command, CancellationToken cancellationToken)
        {
            var routeDetails = await _routeDetailsRepository.DeleteRouteDetailsAsync(command.RDId);
            if (routeDetails == null)
            {
                return default;
            }
            return 1;
        }
    }
}

