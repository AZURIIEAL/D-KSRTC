using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Location
{
    public interface ILocationRepository
    {
        public Task<List<LocationDetails>> GetAllLocationsAsync();
        public Task<LocationDetails?> GetLocationByIdAsync(int LocationId);
        public Task<LocationDetails> AddLocationAsync(LocationDetails locationDetails);
        public Task<LocationDetails> UpdateLocationAsync(LocationDetails locationDetails);
        public Task<LocationDetails?> DeleteLocationAsync(int LocationId);
    }
}
