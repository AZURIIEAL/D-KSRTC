using MediatR;

namespace D_KSRTC.Requests.Commands.RouteDetails.DeleteRouteDetails
{
    public class DeleteRouteDetailsCommand : IRequest<int>
    {
        public int RDId { get; set; }
    }
}