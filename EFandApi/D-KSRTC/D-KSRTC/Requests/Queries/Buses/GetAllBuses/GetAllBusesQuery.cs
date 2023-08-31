using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Buses.GetAllBuses
{
    public class GetAllBusesQuery : IRequest<List<Bus>>
    {
    }

}
