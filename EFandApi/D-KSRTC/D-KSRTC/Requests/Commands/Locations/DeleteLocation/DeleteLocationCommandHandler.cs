using D_KSRTC.Repositories.Location;
using MediatR;

namespace D_KSRTC.Requests.Commands.Locations.DeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, int>
    {
        private readonly ILocationRepository _locationRepository;
        public DeleteLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<int> Handle(DeleteLocationCommand command, CancellationToken cancellationToken)
        {
            var locationDetails = await _locationRepository.DeleteLocationAsync(command.Id);
            if (locationDetails == null)
            { return default; }
            return 1;
        }
    }
}
