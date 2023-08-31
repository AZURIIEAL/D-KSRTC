using D_KSRTC.Repositories.Buses;
using MediatR;

namespace D_KSRTC.Requests.Commands.Buses.DeleteBus
{
    public class DeleteBusCommandHandler : IRequestHandler<DeleteBusCommand, int>
    {
        private readonly IBusRepository _busRepository;

        public DeleteBusCommandHandler(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<int> Handle(DeleteBusCommand command, CancellationToken cancellationToken)
        {
            var busDetails = await _busRepository.DeleteBusTypeCategoryAsync(command.BusId);
            if (busDetails == null)
            {
                return default;
            }
            return 1;
        }
    }
}