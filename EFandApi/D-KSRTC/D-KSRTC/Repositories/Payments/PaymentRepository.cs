using D_KSRTC.Data;
using D_KSRTC.Models;
using Microsoft.EntityFrameworkCore;

namespace D_KSRTC.Repositories.Payments
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DKSRTCContext _dbContext;

        public PaymentRepository(DKSRTCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payment> AddPaymentAsync(Payment paymentDetails)
        {
            try
            {
                _dbContext.Payment.Add(paymentDetails);
                await _dbContext.SaveChangesAsync();
                return paymentDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> DeletePaymentAsync(int paymentId)
        {
            try
            {
                var payment = await _dbContext.Payment.FindAsync(paymentId);
                if (payment != null)
                {
                    _dbContext.Payment.Remove(payment);
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

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            try
            {
                return await _dbContext.Payment.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Payment?> GetPaymentByIdAsync(int paymentId)
        {
            try
            {
                return await _dbContext.Payment.FindAsync(paymentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<int> UpdatePaymentAsync(Payment paymentDetails)
        {
            try
            {
                _dbContext.Entry(paymentDetails).State = EntityState.Modified;
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

