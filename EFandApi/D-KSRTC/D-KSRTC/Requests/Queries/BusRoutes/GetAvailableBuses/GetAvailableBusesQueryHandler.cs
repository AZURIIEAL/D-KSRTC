using D_KSRTC.DTO_s;
using D_KSRTC.Repositories.BusRoutes;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusRoutes.GetAvailableBuses
{
    public class GetAvailableBusesQueryHandler : IRequestHandler<GetAvailableBusesQuery, List<AvailableBuses>>
    {
        private readonly IBusRoutesRepository _busRouteRepository;

        public GetAvailableBusesQueryHandler(IBusRoutesRepository busRouteRepository)
        {
            _busRouteRepository = busRouteRepository;
        }
        public async Task<List<AvailableBuses>> Handle(GetAvailableBusesQuery request, CancellationToken cancellationToken)
        {
            return await _busRouteRepository.GetAvailableBusesAsync(request.FromId, request.ToId, request.Date);
        }
    }
}
