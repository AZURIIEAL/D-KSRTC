using D_KSRTC.Models;
using D_KSRTC.Repositories.BusTypes;
using D_KSRTC.Repositories.Location;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace D_KSRTC.Requests.Commands.BusTypes.AddBusType
{
    public class AddBusTypeCommandHandler : IRequestHandler<AddBusTypeCommand, BusType>
    {
        private readonly BusTypeRepository _busTypeRepository;

        public AddBusTypeCommandHandler(ILocationRepository busTypeRepository)
        {
            _busTypeRepository = busTypeRepository;
        }

        public AddBusTypeCommandHandler(BusTypeRepository? busTypeRepository) { }
        public async Task<BusType> Handle(AddBusTypeCommand command, CancellationToken cancellationToken)
        {
            var busType = new BusType()
            {
                TypeName = command.TypeName
            };

            return await _busTypeRepository.AddBusTypeAsync(busType);
        }
    }
}
