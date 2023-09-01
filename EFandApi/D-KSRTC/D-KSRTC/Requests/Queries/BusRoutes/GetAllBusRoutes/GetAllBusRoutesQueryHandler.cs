using D_KSRTC.Models;
using D_KSRTC.Repositories.BusRoutes;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusRoutes.GetAllBusRoutes
{
    public class GetAllBusRoutesQueryHandler : IRequestHandler<GetAllBusRoutesQuery, List<BusRoute>>
    {
        private readonly IBusRoutesRepository _busRouteRepository;

        public GetAllBusRoutesQueryHandler(IBusRoutesRepository busRouteRepository)
        {
            _busRouteRepository = busRouteRepository;
        }

        public async Task<List<BusRoute>> Handle(GetAllBusRoutesQuery query, CancellationToken cancellationToken)
        {
            return await _busRouteRepository.GetAllBusRoutesAsync();
        }
    }
}
