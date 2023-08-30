using D_KSRTC.Repositories.Location;
using MediatR;


namespace D_KSRTC.Requests.Commands.Location.UpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, int>
    {
        private readonly ILocationRepository _locationRepository;

        public UpdateLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        //NEED TO CHECK LATER.
        public async Task<int> Handle(UpdateLocationCommand command, CancellationToken cancellationToken)
        {
            var locationDetails = await _locationRepository.GetLocationByIdAsync(command.Id);
            if (locationDetails == null)
                return default;
            locationDetails.LocationName = command.LocationName;
            await _locationRepository.UpdateLocationAsync(locationDetails);
            return default;

        }
    }
}
