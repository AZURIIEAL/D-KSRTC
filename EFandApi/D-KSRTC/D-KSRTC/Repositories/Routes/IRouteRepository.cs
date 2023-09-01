using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Routes
{
    public interface IRouteRepository
    {
        Task<List<Models.Route>> GetAllRoutesAsync();
        Task<Models.Route?> GetRouteByIdAsync(int routeId);
        Task<Models.Route> AddRouteAsync(Models.Route route);
        Task<Models.Route> UpdateRouteAsync(Models.Route route);
        Task<Models.Route?> DeleteRouteAsync(int routeId);
    }
}
