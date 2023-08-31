using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.BusTypeCategories
{
        public class BusTypeCategoryRepository : IBusTypeCategoryRepository
        {
            private readonly DKSRTCContext _dbContext;

            public BusTypeCategoryRepository(DKSRTCContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<BusTypeCategory> AddBusTypeCategoryAsync(BusTypeCategory tcDetails)
            {
                _dbContext.BusTypeCategory.Add(tcDetails);
                await _dbContext.SaveChangesAsync();
                return tcDetails;
            }

            public async Task<BusTypeCategory?> DeleteBusTypeCategoryAsync(int tcId)
            {
                var tc = await _dbContext.BusTypeCategory.FindAsync(tcId);
                if (tc != null)
                {
                    _dbContext.BusTypeCategory.Remove(tc);
                    await _dbContext.SaveChangesAsync();
                }
                return tc;
            }

            public async Task<List<BusTypeCategory>> GetAllBusTypeCategoryAsync()
            {
                return await _dbContext.BusTypeCategory
                    .Include(tc => tc.CategoryIdNavigaton)
                    .Include(tc => tc.TypeIdNavigaton)
                    .ToListAsync();
            }

            public async Task<BusTypeCategory?> GetBusTypeCategoryByIdAsync(int tcId)
            {
                return await _dbContext.BusTypeCategory
                    .Include(tc => tc.CategoryIdNavigaton)
                    .Include(tc => tc.TypeIdNavigaton)
                    .FirstOrDefaultAsync(tc => tc.TCId == tcId);
            }

            public async Task<BusTypeCategory> UpdateBusTypeCategoryAsync(BusTypeCategory tcDetails)
            {
                _dbContext.Entry(tcDetails).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return tcDetails;
            }
        }
    }