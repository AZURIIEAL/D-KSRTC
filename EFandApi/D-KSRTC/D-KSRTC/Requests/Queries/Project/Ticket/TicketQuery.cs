using D_KSRTC.DTO_s;
using MediatR;
namespace D_KSRTC.Requests.Queries.Project.Ticket
{
    public class TicketQuery : IRequest<List<TicketDTO>>
    {
        public int UserId { get; set; }
        public TicketQuery()
        {

        }
    }

}