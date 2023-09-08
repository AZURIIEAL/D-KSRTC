using D_KSRTC.Data;
using D_KSRTC.DTO_s;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

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

        public async Task<List<AvailableBuses>> GetAvailableBusesAsync(int fromId, int toId ,DateTime Ondate)
        {
            try
            {
                var res = await _dbContext.BusRoute
                    .Include(x => x.Route)
                    .ThenInclude(x => x!.RouteDetails)
                    .Include(x => x.BusIdNavigation)
                    .ThenInclude(x => x!.TCIdNavigation).ThenInclude(x => x!.CategoryIdNavigaton)
                    .ThenInclude(x => x!.BusTypeCategories)
                    .Where(x => x.Route!.SLId == fromId && x.Route.RouteDetails.Any(y => y.StopId == toId) && x.RouteDate.Date == Ondate.Date)
                    .Select(x => new AvailableBuses
                    {
                        BusId = x.BusId,
                        BusName = x.BusIdNavigation!.BusName,
                        Time = x.Time,
                        Distance = x.Route!.Distance,
                        SeatAvailability = 0,
                        Duration = x.Route!.Duration,
                        Sequence = x.Route.RouteDetails.Where(y => y.StopId == toId).Select(x => x.Sequence).First(),
                        CategoryName = x.BusIdNavigation.TCIdNavigation!.CategoryIdNavigaton!.CategoryName,
                        TypeName = x.BusIdNavigation.TCIdNavigation.TypeIdNavigaton!.TypeName,
                        BaseFare = x.BusIdNavigation.TCIdNavigation.CategoryIdNavigaton.BaseFare,
                        perDistanceFare = x.BusIdNavigation.TCIdNavigation.TypeIdNavigaton.PDF

                    })
                    .ToListAsync();

                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
