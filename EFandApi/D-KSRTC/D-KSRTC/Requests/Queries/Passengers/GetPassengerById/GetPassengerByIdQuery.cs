using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Passengers.GetPassengerById
{
    public class GetPassengerByIdQuery : IRequest<Passenger>
    {
        public int PassengerId { get; set; }

        public GetPassengerByIdQuery(int passengerId)
        {
            PassengerId = passengerId;
        }
    }
}
