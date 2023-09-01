using D_KSRTC.Models;
using D_KSRTC.Repositories.BusRoutes;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusRoutes.GetBusRouteById
{
    public class GetBusRouteByIdQueryHandler : IRequestHandler<GetBusRouteByIdQuery, BusRoute>
    {
        private readonly IBusRoutesRepository _busRouteRepository;

        public GetBusRouteByIdQueryHandler(IBusRoutesRepository busRouteRepository)
        {
            _busRouteRepository = busRouteRepository;
        }

        public async Task<BusRoute> Handle(GetBusRouteByIdQuery query, CancellationToken cancellationToken)
        {
            var res = await _busRouteRepository.GetBusRouteByIdAsync(query.BusRouteId);
            return res ?? new BusRoute();
        }
    }
}
