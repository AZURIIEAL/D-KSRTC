using D_KSRTC.Models;
using MediatR;


public class GetRouteDetailsByIdQuery : IRequest<RouteDetails>
{
    public int RDId { get; set; }
}

