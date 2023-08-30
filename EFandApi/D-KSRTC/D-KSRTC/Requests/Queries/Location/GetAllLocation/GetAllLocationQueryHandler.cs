using D_KSRTC.Models;
using D_KSRTC.Repositories.Location;
using MediatR;

namespace D_KSRTC.Requests.Queries.Location.GetAllLocation
{
    public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationsQuery, List<LocationDetails>>
    {
        public readonly ILocationRepository _locationRepository;
        public GetAllLocationQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<LocationDetails>> Handle(GetAllLocationsQuery query, CancellationToken cancellationToken)
        {
            return await _locationRepository.GetAllLocationsAsync();
        }
    }
}
