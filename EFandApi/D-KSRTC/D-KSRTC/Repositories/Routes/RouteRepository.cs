using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.Routes
{
    public class RouteRepository : IRouteRepository
    {
        private readonly DKSRTCContext _dbContext;

        public RouteRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Models.Route> AddRouteAsync(Models.Route route)
        {
            try
            {
                _dbContext.Route.Add(route);
                await _dbContext.SaveChangesAsync();
                return route;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Models.Route?> DeleteRouteAsync(int routeId)
        {
            try
            {
                var route = await _dbContext.Route.FindAsync(routeId);
                if (route != null)
                {
                    _dbContext.Route.Remove(route);
                    await _dbContext.SaveChangesAsync();
                }
                return route;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Models.Route>> GetAllRoutesAsync()
        {
            try
            {
                return await _dbContext.Route.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Models.Route?> GetRouteByIdAsync(int routeId)
        {
            try
            {
                return await _dbContext.Route.FindAsync(routeId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Models.Route> UpdateRouteAsync(Models.Route route)
        {
            try
            {
                _dbContext.Entry(route).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return route;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}