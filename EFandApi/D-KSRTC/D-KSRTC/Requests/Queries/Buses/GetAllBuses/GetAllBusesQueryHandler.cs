using D_KSRTC.Models;
using D_KSRTC.Repositories.Buses;
using MediatR;

namespace D_KSRTC.Requests.Queries.Buses.GetAllBuses
{
    public class GetAllBusesQueryHandler : IRequestHandler<GetAllBusesQuery, List<Bus>>
    {
        private readonly IBusRepository _busRepository;

        public GetAllBusesQueryHandler(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<List<Bus>> Handle(GetAllBusesQuery query, CancellationToken cancellationToken)
        {
            return await _busRepository.GetAllBusTypeCategoryAsync();
        }
    }
}
