using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Location.GetLocationById
{
    public class GetLocationByIdQuery : IRequest<LocationDetails>
    {
        public int Id { get; set; }
    }
}
