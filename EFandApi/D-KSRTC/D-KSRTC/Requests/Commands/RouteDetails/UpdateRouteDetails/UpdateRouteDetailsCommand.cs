using MediatR;

namespace D_KSRTC.Requests.Commands.RouteDetails.UpdateRouteDetails
{
    public class UpdateRouteDetailsCommand : IRequest<int>
    {
        public int RDId { get; set; }
        public int RouteId { get; set; }
        public int StopId { get; set; }
        public int Sequence { get; set; }
        public float Distance { get; set; }
        public DateTime Duration { get; set; }
    }
}
