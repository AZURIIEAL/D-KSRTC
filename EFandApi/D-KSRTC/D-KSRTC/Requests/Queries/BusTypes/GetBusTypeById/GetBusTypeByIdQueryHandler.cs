using D_KSRTC.Models;
using D_KSRTC.Repositories.BusTypes;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusTypes.GetBusTypeById
{
    public class GetBusTypeByIdQueryHandler : IRequestHandler<GetBusTypeByIdQuery, BusType>
    {
        private readonly IBusTypeRepository _busTypeRepository;

        public GetBusTypeByIdQueryHandler(IBusTypeRepository busTypeRepository)
        {
            _busTypeRepository = busTypeRepository;
        }

        public async Task<BusType> Handle(GetBusTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var busType = await _busTypeRepository.GetBusTypeByIdAsync(request.TypeId);
            return busType ?? new BusType();
        }
    }
}
