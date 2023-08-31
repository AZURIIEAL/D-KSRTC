using D_KSRTC.Models;
using D_KSRTC.Repositories.Buses;
using MediatR;

namespace D_KSRTC.Requests.Queries.Buses.GetBusById
{
    public class GetBusByIdQueryHandler : IRequestHandler<GetBusByIdQuery, Bus>
    {
        private readonly IBusRepository _busRepository;

        public GetBusByIdQueryHandler(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<Bus> Handle(GetBusByIdQuery query, CancellationToken cancellationToken)
        {
            var busDetails = await _busRepository.GetBusTypeCategoryByIdAsync(query.BusId);
            return busDetails ?? new Bus();
        }
    }
}