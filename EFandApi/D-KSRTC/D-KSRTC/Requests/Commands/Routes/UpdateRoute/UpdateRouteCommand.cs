using MediatR;

namespace D_KSRTC.Requests.Commands.Routes.UpdateRoute
{
    public class UpdateRouteCommand : IRequest<int>
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; } = string.Empty;
        public int SLId { get; set; }
        public int? ELId { get; set; }
        public float Distance { get; set; }
        public DateTime Duration { get; set; }
    }
}
