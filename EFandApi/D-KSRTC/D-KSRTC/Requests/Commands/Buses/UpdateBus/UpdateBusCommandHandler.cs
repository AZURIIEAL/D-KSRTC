using D_KSRTC.Repositories.Buses;
using MediatR;

namespace D_KSRTC.Requests.Commands.Buses.UpdateBus
{
    public class UpdateBusCommandHandler : IRequestHandler<UpdateBusCommand, int>
    {
        private readonly IBusRepository _busRepository;

        public UpdateBusCommandHandler(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<int> Handle(UpdateBusCommand command, CancellationToken cancellationToken)
        {
            var busDetails = await _busRepository.GetBusTypeCategoryByIdAsync(command.BusId);
            if (busDetails == null)
            {
                throw new FileNotFoundException($"Bus with ID {command.BusId} not found.");
            }

            busDetails.BusName = command.BusName;
            busDetails.TCId = command.TCId;
            busDetails.TotalSeats = command.TotalSeats;

            await _busRepository.UpdateBusTypeCategoryAsync(busDetails);
            return 1;
        }
    }
}
}
