using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.BusCategories
{
    public class BusCategoryRepository : IBusCategoryRepository
    {
        private readonly DKSRTCContext _dbContext;

        public BusCategoryRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BusCategory> AddBusCategoryAsync(BusCategory categoryDetails)
        {
            _dbContext.BusCategory.Add(categoryDetails);
            await _dbContext.SaveChangesAsync();
            return categoryDetails;
        }

        public async Task<BusCategory?> DeleteBusCategoryAsync(int categoryId)
        {
            var category = await _dbContext.BusCategory.FindAsync(categoryId);
            if (category != null)
            {
                _dbContext.BusCategory.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
            return category;
        }

        public async Task<List<BusCategory>> GetAllBusCategoryAsync()
        {
            return await _dbContext.BusCategory.ToListAsync();
        }

        public async Task<BusCategory?> GetBusCategoryByIdAsync(int categoryId)
        {
            return await _dbContext.BusCategory.FindAsync(categoryId);
        }

        public async Task<BusCategory> UpdateBusCategoryAsync(BusCategory categoryDetails)
        {
            _dbContext.Entry(categoryDetails).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return categoryDetails;
        }
    }
}
