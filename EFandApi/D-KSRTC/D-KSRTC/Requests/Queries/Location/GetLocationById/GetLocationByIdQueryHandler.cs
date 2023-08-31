using D_KSRTC.Models;
using D_KSRTC.Repositories.Location;
using MediatR;

namespace D_KSRTC.Requests.Queries.Location.GetLocationById
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, LocationDetails>
    {
        private readonly ILocationRepository _locationRepository;
        public GetLocationByIdQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<LocationDetails> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            LocationDetails? locationDetails =  await _locationRepository.GetLocationByIdAsync(request.Id);
            return locationDetails ?? new LocationDetails();
        }
    }
}
