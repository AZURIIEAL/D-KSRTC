using D_KSRTC.Repositories.BusRoutes;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusRoutes.DeleteBusRoute
{
    public class DeleteBusRouteCommandHandler : IRequestHandler<DeleteBusRouteCommand, int>
    {
        private readonly IBusRoutesRepository _busRouteRepository;

        public DeleteBusRouteCommandHandler(IBusRoutesRepository busRouteRepository)
        {
            _busRouteRepository = busRouteRepository;
        }

        public async Task<int> Handle(DeleteBusRouteCommand command, CancellationToken cancellationToken)
        {
            return await _busRouteRepository.DeleteBusRouteAsync(command.BusRouteId);
        }
    }
}
