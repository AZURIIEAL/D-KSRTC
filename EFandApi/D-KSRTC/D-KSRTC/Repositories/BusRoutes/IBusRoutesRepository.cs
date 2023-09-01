using D_KSRTC.Models;

namespace D_KSRTC.Repositories.BusRoutes
{
    public interface IBusRoutesRepository
    {
        Task<BusRoute> AddBusRouteAsync(BusRoute busRoute);
        Task<int> UpdateBusRouteAsync(BusRoute busRoute);
        Task<int> DeleteBusRouteAsync(int busRouteId);
        Task<List<BusRoute>> GetAllBusRoutesAsync();
        Task<BusRoute?> GetBusRouteByIdAsync(int busRouteId);
    }
}
