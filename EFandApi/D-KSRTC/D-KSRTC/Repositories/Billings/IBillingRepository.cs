using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Billings
{
    public interface IBillingRepository
    {
        Task<Billing> AddBillingAsync(Billing billing);
        Task<int> DeleteBillingAsync(int billingId);
        Task<List<Billing>> GetAllBillingsAsync();
        Task<Billing?> GetBillingByIdAsync(int billingId);
        Task<int> UpdateBillingAsync(Billing billing);
    }
}
