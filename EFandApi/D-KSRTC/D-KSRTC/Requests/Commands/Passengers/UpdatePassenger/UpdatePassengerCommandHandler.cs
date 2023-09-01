using D_KSRTC.Repositories.Passengers;
using MediatR;

namespace D_KSRTC.Requests.Commands.Passengers.UpdatePassenger
{
    public class UpdatePassengerCommandHandler : IRequestHandler<UpdatePassengerCommand, int>
    {
        private readonly IPassengerRepository _passengerRepository;

        public UpdatePassengerCommandHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<int> Handle(UpdatePassengerCommand command, CancellationToken cancellationToken)
        {
            var passenger = await _passengerRepository.GetPassengerByIdAsync(command.PassengerId);
            if (passenger == null)
            {
                return default;
            }

            passenger.FirstName = command.FirstName;
            passenger.LastName = command.LastName;
            passenger.Age = command.Age;
            passenger.Gender = command.Gender;
            passenger.SeatId = command.SeatId;
            passenger.PhoneNumber = command.PhoneNumber;
            passenger.Email = command.Email;

            return 1;
        }
    }
}

