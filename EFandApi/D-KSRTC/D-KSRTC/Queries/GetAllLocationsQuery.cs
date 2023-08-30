using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Queries
{
    public class GetAllLocationsQuery : IRequest<List<LocationDetails>>
    {
    }
}
