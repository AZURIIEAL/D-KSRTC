using D_KSRTC.Repositories.BusTypes;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypes.DeleteBusType
{
    public class DeleteBusTypeCommandHandler : IRequestHandler<DeleteBusTypeCommand, int>
    {
        private readonly IBusTypeRepository _busTypeRepository;

        public DeleteBusTypeCommandHandler(IBusTypeRepository busTypeRepository)
        {
            _busTypeRepository = busTypeRepository;
        }

        public async Task<int> Handle(DeleteBusTypeCommand command, CancellationToken cancellationToken)
        {
            var busType = await _busTypeRepository.DeleteBusTypeAsync(command.TypeId);
            if (busType == null)
            {
                return default;
            }
            return 1;
        }
    }
}
