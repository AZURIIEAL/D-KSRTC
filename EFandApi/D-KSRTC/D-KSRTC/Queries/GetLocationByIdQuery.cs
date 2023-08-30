using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Queries
{
    public class GetLocationByIdQuery : IRequest<LocationDetails>
    {
        public int Id { get; set; }
    }
}
