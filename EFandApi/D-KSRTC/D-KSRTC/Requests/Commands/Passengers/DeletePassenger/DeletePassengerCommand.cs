using MediatR;

namespace D_KSRTC.Requests.Commands.Passengers.DeletePassenger
{
    public class DeletePassengerCommand : IRequest<int>
    {
        public int PassengerId { get; set; }

        public DeletePassengerCommand(int passengerId)
        {
            PassengerId = passengerId;
        }
    }
}
