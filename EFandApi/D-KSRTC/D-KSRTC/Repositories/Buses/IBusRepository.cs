using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Buses
{
    public interface IBusRepository
    {
        public Task<List<Bus>> GetAllBusTypeCategoryAsync();
        public Task<Bus?> GetBusTypeCategoryByIdAsync(int busId);
        public Task<Bus> AddBusTypeCategoryAsync(Bus busDetails);
        public Task<Bus> UpdateBusTypeCategoryAsync(Bus busDetails);
        public Task<Bus?> DeleteBusTypeCategoryAsync(int busId);
    }
}
