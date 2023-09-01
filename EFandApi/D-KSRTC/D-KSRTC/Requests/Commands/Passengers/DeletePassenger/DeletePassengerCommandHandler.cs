using D_KSRTC.Repositories.Passengers;
using MediatR;

namespace D_KSRTC.Requests.Commands.Passengers.DeletePassenger
{
    public class DeletePassengerCommandHandler : IRequestHandler<DeletePassengerCommand, int>
    {
        private readonly IPassengerRepository _passengerRepository;

        public DeletePassengerCommandHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<int> Handle(DeletePassengerCommand command, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.DeletePassengerAsync(command.PassengerId);
            if (passenger == null)
            {
                return default;
            }

            return 1;
        }
    }

}
