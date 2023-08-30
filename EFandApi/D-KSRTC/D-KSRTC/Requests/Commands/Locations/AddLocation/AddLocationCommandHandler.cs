using D_KSRTC.Models;
using D_KSRTC.Repositories.Location;
using MediatR;

namespace D_KSRTC.Requests.Commands.Location.AddLocation
{
    public class AddLocationCommandHandler : IRequestHandler<AddLocationCommand, LocationDetails>
    {
        private readonly ILocationRepository _locationRepository;

        public AddLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<LocationDetails> Handle(AddLocationCommand command, CancellationToken cancellationToken)
        {
            var locationDetails = new LocationDetails()
            {
                LocationName = command.LocationName
            };

            return await _locationRepository.AddLocationAsync(locationDetails);
        }
    }
}
