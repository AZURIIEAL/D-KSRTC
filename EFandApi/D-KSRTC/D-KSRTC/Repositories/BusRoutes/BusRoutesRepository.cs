using D_KSRTC.Data;
using D_KSRTC.DTO_s;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.BusRoutes
{
    public class BusRoutesRepository : IBusRoutesRepository
    {
        private readonly DKSRTCContext _dbContext;

        public BusRoutesRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BusRoute> AddBusRouteAsync(BusRoute busRoute)
        {
            try
            {
                _dbContext.BusRoute.Add(busRoute);
                await _dbContext.SaveChangesAsync();
                return busRoute;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> UpdateBusRouteAsync(BusRoute busRoute)
        {
            try
            {
                _dbContext.Entry(busRoute).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> DeleteBusRouteAsync(int busRouteId)
        {
            try
            {
                var busRoute = await _dbContext.BusRoute.FindAsync(busRouteId);
                if (busRoute != null)
                {
                    _dbContext.BusRoute.Remove(busRoute);
                    await _dbContext.SaveChangesAsync();
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<BusRoute>> GetAllBusRoutesAsync()
        {
            try
            {
                return await _dbContext.BusRoute.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<BusRoute?> GetBusRouteByIdAsync(int busRouteId)
        {
            try
            {
                return await _dbContext.BusRoute.FindAsync(busRouteId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<AvailableBuses>> GetAvailableBusesAsync(int fromId, int toId)
        {
            try
            {
                return await _dbContext.BusRoute.Include(x => x.Route)
                    .ThenInclude(x => x.RouteDetails)
                    .Where(x => x.Route.SLId == fromId && x.Route.RouteDetails.Any(y => y.StopId == toId))
                    .Select(x => new AvailableBuses
                    {

                    })
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
