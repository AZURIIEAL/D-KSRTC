using D_KSRTC.Models;
using D_KSRTC.Repositories.BusTypes;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypes.AddBusType
{
    public class AddBusTypeCommandHandler : IRequestHandler<AddBusTypeCommand, BusType>
    {
        private readonly IBusTypeRepository _busTypeRepository;

        public AddBusTypeCommandHandler(IBusTypeRepository busTypeRepository)
        {
            _busTypeRepository = busTypeRepository;
        }

        public async Task<BusType> Handle(AddBusTypeCommand command, CancellationToken cancellationToken)
        {
            var busType = new BusType()
            {
                TypeName = command.TypeName,
                PDF = command.PDF
            };

            return await _busTypeRepository.AddBusTypeAsync(busType);
        }
    }
}
