using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;
namespace D_KSRTC.Repositories.Location
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DKSRTCContext _dbContext;

        public LocationRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LocationDetails> AddLocationAsync(LocationDetails locationDetails)
        {
            try
            {
                _dbContext.Location.Add(locationDetails);
                await _dbContext.SaveChangesAsync();
                return locationDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<LocationDetails?> DeleteLocationAsync(int LocationId)
        {
            try
            {
                var location = await _dbContext.Location.FindAsync(LocationId);
                if (location != null)
                {
                    _dbContext.Location.Remove(location);
                    await _dbContext.SaveChangesAsync();
                }
                return location;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<LocationDetails>> GetAllLocationsAsync()
        {
            try
            {
                return await _dbContext.Location.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<LocationDetails> GetLocationByIdAsync(int LocationId)
        {
            try
            {
                return await _dbContext.Location.FindAsync(LocationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<LocationDetails> UpdateLocationAsync(LocationDetails locationDetails)
        {
            try
            {
                _dbContext.Entry(locationDetails).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return locationDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            } 
        }
    }
}
