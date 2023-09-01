using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Passengers.GetAllPassengers
{
    public class GetAllPassengersQuery : IRequest<List<Passenger>>
    {
    }
}
