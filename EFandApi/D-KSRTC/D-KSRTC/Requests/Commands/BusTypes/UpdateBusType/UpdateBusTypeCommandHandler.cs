using D_KSRTC.Repositories.BusTypes;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypes.UpdateBusType
{
    public class UpdateBusTypeCommandHandler : IRequestHandler<UpdateBusTypeCommand, int>
    {
        private readonly IBusTypeRepository _busTypeRepository;

        public UpdateBusTypeCommandHandler(IBusTypeRepository busTypeRepository)
        {
            _busTypeRepository = busTypeRepository;
        }

        public async Task<int> Handle(UpdateBusTypeCommand command, CancellationToken cancellationToken)
        {
            var busType = await _busTypeRepository.GetBusTypeByIdAsync(command.TypeId);
            if (busType == null)
            {
                return default;
            }

            busType.TypeName = command.TypeName;
            busType.PDF = command.PDF;
            await _busTypeRepository.UpdateBusTypeAsync(busType);
            return 1;
        }
    }
}
