using D_KSRTC.Repositories.Routes;
using MediatR;

namespace D_KSRTC.Requests.Commands.Routes.UpdateRoute
{
    public class UpdateRouteCommandHandler : IRequestHandler<UpdateRouteCommand, int>
    {
        private readonly IRouteRepository _routeRepository;

        public UpdateRouteCommandHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<int> Handle(UpdateRouteCommand command, CancellationToken cancellationToken)
        {
            var route = await _routeRepository.GetRouteByIdAsync(command.RouteId);
            if (route == null)
            {
                return default;
            }

            route.RouteName = command.RouteName;
            route.SLId = command.SLId;
            route.ELId = command.ELId;
            route.Distance = command.Distance;
            route.Duration = command.Duration;

            await _routeRepository.UpdateRouteAsync(route);
            return 1;
        }
    }
}
