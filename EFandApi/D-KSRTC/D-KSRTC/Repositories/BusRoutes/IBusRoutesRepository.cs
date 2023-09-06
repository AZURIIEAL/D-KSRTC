using D_KSRTC.DTO_s;
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
        Task<List<AvailableBuses>> GetAvailableBusesAsync(int fromId,int toId);
    }
}
