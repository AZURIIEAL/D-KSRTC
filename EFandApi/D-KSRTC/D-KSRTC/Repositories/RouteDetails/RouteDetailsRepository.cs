using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

public class RouteDetailsRepository : IRouteDetailsRepository
{
    private readonly DKSRTCContext _dbContext;

    public RouteDetailsRepository(DKSRTCContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RouteDetails> AddRouteDetailsAsync(RouteDetails routeDetails)
    {
        try
        {
            _dbContext.RouteDetails.Add(routeDetails);
            await _dbContext.SaveChangesAsync();
            return routeDetails;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<RouteDetails?> DeleteRouteDetailsAsync(int RDId)
    {
        try
        {
            var routeDetails = await _dbContext.RouteDetails.FindAsync(RDId);
            if (routeDetails != null)
            {
                _dbContext.RouteDetails.Remove(routeDetails);
                await _dbContext.SaveChangesAsync();
            }
            return routeDetails;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<List<RouteDetails>> GetAllRouteDetailsAsync()
    {
        try
        {
            return await _dbContext.RouteDetails.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<RouteDetails?> GetRouteDetailsByIdAsync(int RDId)
    {
        try
        {
            return await _dbContext.RouteDetails.FindAsync(RDId);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<RouteDetails> UpdateRouteDetailsAsync(RouteDetails routeDetails)
    {
        try
        {
            _dbContext.Entry(routeDetails).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return routeDetails;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}
