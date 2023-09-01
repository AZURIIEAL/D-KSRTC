using D_KSRTC.Repositories.Routes;
using MediatR;

namespace D_KSRTC.Requests.Commands.Routes.AddRoute
{
    public class AddRouteCommandHandler : IRequestHandler<AddRouteCommand, Models.Route>
    {
        private readonly IRouteRepository _routeRepository;

        public AddRouteCommandHandler(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<Models.Route> Handle(AddRouteCommand command, CancellationToken cancellationToken)
        {
            var route = new Models.Route()
            {
                RouteName = command.RouteName,
                SLId = command.SLId,
                ELId = command.ELId,
                Distance = command.Distance,
                Duration = command.Duration
            };

            return await _routeRepository.AddRouteAsync(route);
        }
    }
}
