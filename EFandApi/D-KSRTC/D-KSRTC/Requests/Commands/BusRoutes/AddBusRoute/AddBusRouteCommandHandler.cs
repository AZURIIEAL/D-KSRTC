using D_KSRTC.Models;
using D_KSRTC.Repositories.BusRoutes;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusRoutes.AddBusRouteCommand
{
    public class AddBusRouteCommandHandler : IRequestHandler<AddBusRouteCommand, BusRoute>
    {
        private readonly IBusRoutesRepository _busRouteRepository;

        public AddBusRouteCommandHandler(IBusRoutesRepository busRouteRepository)
        {
            _busRouteRepository = busRouteRepository;
        }

        public async Task<BusRoute> Handle(AddBusRouteCommand command, CancellationToken cancellationToken)
        {
            var busRoute = new BusRoute
            {
                BusId = command.BusId,
                RouteId = command.RouteId,
                TimeId = command.TimeId,
                RouteDate = command.RouteDate,
            };

            return await _busRouteRepository.AddBusRouteAsync(busRoute);
        }
    }
}
