using MediatR;

namespace D_KSRTC.Requests.Commands.Project.TicketCancellation
{
    public class TicketCancellationCommand :IRequest<bool>
    {
        public int passengerId { get; set; }
 
    }
}

