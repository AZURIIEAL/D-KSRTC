using D_KSRTC.Models;
using D_KSRTC.Repositories.Passengers;
using MediatR;

namespace D_KSRTC.Requests.Queries.Passengers.GetAllPassengers
{
    public class GetAllPassengersQueryHandler : IRequestHandler<GetAllPassengersQuery, List<Passenger>>
    {
        private readonly IPassengerRepository _passengerRepository;

        public GetAllPassengersQueryHandler(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<List<Passenger>> Handle(GetAllPassengersQuery request, CancellationToken cancellationToken)
        {
            return await _passengerRepository.GetAllPassengersAsync();
        }
    }
}
