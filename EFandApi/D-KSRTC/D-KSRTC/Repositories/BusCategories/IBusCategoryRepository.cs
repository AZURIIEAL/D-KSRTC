using D_KSRTC.Models;

namespace D_KSRTC.Repositories.BusCategories
{
    public interface IBusCategoryRepository
    {
        public Task<List<BusCategory>> GetAllBusCategoryAsync();
        public Task<BusCategory?> GetBusCategoryByIdAsync(int categoryId);
        public Task<BusCategory> AddBusCategoryAsync(BusCategory categoryDetails);
        public Task<BusCategory> UpdateBusCategoryAsync(BusCategory categoryDetails);
        public Task<BusCategory?> DeleteBusCategoryAsync(int categoryId);
    }
}
