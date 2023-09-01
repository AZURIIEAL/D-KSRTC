using D_KSRTC.Models;
using D_KSRTC.Repositories.Passengers;
using MediatR;

namespace D_KSRTC.Requests.Commands.Passengers.AddPassenger
{
    public class AddPassengerCommandHandler : IRequestHandler<AddPassengerCommand, Passenger>
    {
        private readonly IPassengerRepository _passengerRepository;

        public AddPassengerCommandHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<Passenger> Handle(AddPassengerCommand command, CancellationToken cancellationToken)
        {
            var passenger = new Passenger
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Age = command.Age,
                Gender = command.Gender,
                SeatId = command.SeatId,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email
            };

            return await _passengerRepository.AddPassengerAsync(passenger);
        }
    }
}

