using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Times.GetAllTimes
{
    public class GetAllTimesQuery : IRequest<List<Time>>
    {
    }
}
