using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories
{
    public class LocationRepository : ILocationRepository 
    {
        private readonly DbContextClass _dbContext;

        public LocationRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LocationDetails> AddLocationAsync(LocationDetails locationDetails)
        {
            _dbContext.Location.Add(locationDetails);
            await _dbContext.SaveChangesAsync();
            return locationDetails;
        }

        public async Task<LocationDetails?> DeleteLocationAsync(int LocationId)
        {
            var location = await _dbContext.Location.FindAsync(LocationId);
            if (location != null)
            {
                _dbContext.Location.Remove(location);
                await _dbContext.SaveChangesAsync();
            }
            return location;
        }

        public async Task<List<LocationDetails>> GetAllLocationsAsync()
        {
            return await _dbContext.Location.ToListAsync();
        }

        public async Task<LocationDetails> GetLocationByIdAsync(int LocationId)
        {
            return await _dbContext.Location.FindAsync(LocationId);
        }

        public async Task<LocationDetails> UpdateLocationAsync(LocationDetails locationDetails)
        {
            _dbContext.Entry(locationDetails).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return locationDetails;
        }
    }
}
