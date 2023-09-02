using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Times.GetTimeById
{
    public class GetTimeByIdQuery : IRequest<Time>
    {
        public int TimeId { get; set; }

        public GetTimeByIdQuery(int timeId)
        {
            TimeId = timeId;
        }
    }
}
