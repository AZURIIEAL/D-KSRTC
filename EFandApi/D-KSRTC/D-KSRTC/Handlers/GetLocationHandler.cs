using D_KSRTC.Models;
using D_KSRTC.Queries;
using D_KSRTC.Repositories;
using MediatR;

namespace D_KSRTC.Handlers
{
    public class GetLocationHandler :  IRequestHandler<GetAllLocationsQuery, List<LocationDetails>>
    {
        public readonly ILocationRepository _locationRepository;
        public GetLocationHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<LocationDetails>> Handle(GetAllLocationsQuery query , CancellationToken cancellationToken)
        {
            return await _locationRepository.GetAllLocationsAsync();
        }
    }
}
