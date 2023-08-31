using D_KSRTC.Models;
using D_KSRTC.Repositories.Buses;
using MediatR;

namespace D_KSRTC.Requests.Commands.Buses.AddBus
{
    public class AddBusCommandHandler : IRequestHandler<AddBusCommand, Bus>
    {
        private readonly IBusRepository _busRepository;

        public AddBusCommandHandler(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<Bus> Handle(AddBusCommand command, CancellationToken cancellationToken)
        {
            var busDetails = new Bus
            {
                BusName = command.BusName,
                TCId = command.TCId,
                TotalSeats = command.TotalSeats
            };

            return await _busRepository.AddBusTypeCategoryAsync(busDetails);
        }
    }
}