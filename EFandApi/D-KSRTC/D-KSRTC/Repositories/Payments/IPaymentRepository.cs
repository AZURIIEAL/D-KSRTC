using D_KSRTC.Models;

namespace D_KSRTC.Repositories.Payments
{
    public interface IPaymentRepository
    {
        Task<Payment> AddPaymentAsync(Payment paymentDetails);
        Task<int> DeletePaymentAsync(int paymentId);
        Task<List<Payment>> GetAllPaymentsAsync();
        Task<Payment?> GetPaymentByIdAsync(int paymentId);
        Task<int> UpdatePaymentAsync(Payment paymentDetails);
    }
}
