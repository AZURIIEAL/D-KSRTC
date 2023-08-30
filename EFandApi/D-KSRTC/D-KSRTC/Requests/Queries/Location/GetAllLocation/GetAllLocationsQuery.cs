using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Location.GetAllLocation
{
    public class GetAllLocationsQuery : IRequest<List<LocationDetails>>
    {
    }
}
