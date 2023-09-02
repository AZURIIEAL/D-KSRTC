using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.Billings
{
    public class BillingRepository : IBillingRepository
    {
        private readonly DKSRTCContext _dbContext;

        public BillingRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Billing> AddBillingAsync(Billing billing)
        {
            try
            {
                _dbContext.Billing.Add(billing);
                await _dbContext.SaveChangesAsync();
                return billing;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> DeleteBillingAsync(int billingId)
        {
            try
            {
                var billing = await _dbContext.Billing.FindAsync(billingId);
                if (billing != null)
                {
                    _dbContext.Billing.Remove(billing);
                    await _dbContext.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<Billing>> GetAllBillingsAsync()
        {
            try
            {
                return await _dbContext.Billing.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Billing?> GetBillingByIdAsync(int billingId)
        {
            try
            {
                return await _dbContext.Billing.FindAsync(billingId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> UpdateBillingAsync(Billing billing)
        {
            try
            {
                _dbContext.Entry(billing).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}

