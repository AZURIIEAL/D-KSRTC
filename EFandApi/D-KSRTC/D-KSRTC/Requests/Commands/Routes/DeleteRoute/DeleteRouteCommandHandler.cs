using D_KSRTC.Repositories.Routes;
using MediatR;

namespace D_KSRTC.Requests.Commands.Routes.DeleteRoute
{
    public class DeleteRouteCommandHandler : IRequestHandler<DeleteRouteCommand, int>
    {
        private readonly IRouteRepository _routeRepository;

        public DeleteRouteCommandHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<int> Handle(DeleteRouteCommand command, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.DeleteRouteAsync(command.RouteId);
            if (route == null)
            {
                return default;
            }

            return 1;
        }
    }
}
