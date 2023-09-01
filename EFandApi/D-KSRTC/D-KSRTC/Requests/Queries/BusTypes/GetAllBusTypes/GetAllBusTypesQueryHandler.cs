using D_KSRTC.Models;
using D_KSRTC.Repositories.BusTypes;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusTypes.GetAllBusTypes
{
    public class GetAllBusTypesQueryHandler : IRequestHandler<GetAllBusTypesQuery, List<BusType>>
    {
        private readonly IBusTypeRepository _busTypeRepository;

        public GetAllBusTypesQueryHandler(IBusTypeRepository busTypeRepository)
        {
            _busTypeRepository = busTypeRepository;
        }

        public async Task<List<BusType>> Handle(GetAllBusTypesQuery query, CancellationToken cancellationToken)
        {
            return await _busTypeRepository.GetAllBusTypesAsync();
        }
    }
}
