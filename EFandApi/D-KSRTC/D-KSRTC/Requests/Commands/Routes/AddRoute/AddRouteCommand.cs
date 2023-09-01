using MediatR;

namespace D_KSRTC.Requests.Commands.Routes.AddRoute
{
    public class AddRouteCommand : IRequest<Models.Route>
    {
        public AddRouteCommand(string routeName, int sLId, int? eLId, float distance, DateTime duration)
        {
            RouteName = routeName;
            SLId = sLId;
            ELId = eLId;
            Distance = distance;
            Duration = duration;
        }

        public string RouteName { get; set; } = string.Empty;
        public int SLId { get; set; }
        public int? ELId { get; set; }
        public float Distance { get; set; }
        public DateTime Duration { get; set; }
    }
}
