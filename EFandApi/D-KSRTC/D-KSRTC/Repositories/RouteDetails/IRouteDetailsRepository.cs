using D_KSRTC.Models;
public interface IRouteDetailsRepository
{
    Task<List<RouteDetails>> GetAllRouteDetailsAsync();
    Task<RouteDetails?> GetRouteDetailsByIdAsync(int RDId);
    Task<RouteDetails> AddRouteDetailsAsync(RouteDetails routeDetails);
    Task<RouteDetails> UpdateRouteDetailsAsync(RouteDetails routeDetails);
    Task<RouteDetails?> DeleteRouteDetailsAsync(int RDId);
}
