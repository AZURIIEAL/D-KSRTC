using D_KSRTC.Models;
using D_KSRTC.Repositories.Passengers;
using MediatR;

namespace D_KSRTC.Requests.Queries.Passengers.GetPassengerById
{
    public class GetPassengerByIdQueryHandler : IRequestHandler<GetPassengerByIdQuery, Passenger>
    {
        private readonly IPassengerRepository _passengerRepository;

        public GetPassengerByIdQueryHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<Passenger> Handle(GetPassengerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _passengerRepository.GetPassengerByIdAsync(request.PassengerId) ?? new Passenger();
        }
    }
}
