using D_KSRTC.Models;

namespace D_KSRTC.Repositories.BusTypeCategories
{
    public interface IBusTypeCategoryRepository
    {
        public Task<List<BusTypeCategory>> GetAllBusTypeCategoryAsync();
        public Task<BusTypeCategory?> GetBusTypeCategoryByIdAsync(int TCId);
        public Task<BusTypeCategory> AddBusTypeCategoryAsync(BusTypeCategory TCDetails);
        public Task<BusTypeCategory> UpdateBusTypeCategoryAsync(BusTypeCategory TCDetails);
        public Task<BusTypeCategory?> DeleteBusTypeCategoryAsync(int TCId);
    }
}
