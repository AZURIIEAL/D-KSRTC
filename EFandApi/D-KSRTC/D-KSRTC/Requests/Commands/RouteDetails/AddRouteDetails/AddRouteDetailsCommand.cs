using MediatR;
using D_KSRTC.Models;

public class AddRouteDetailsCommand : IRequest<RouteDetails>
{
    public int RouteId { get; set; }
    public int StopId { get; set; }
    public int Sequence { get; set; }
    public float Distance { get; set; }
    public DateTime Duration { get; set; }
}

