using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Billings.AddBilling
{
    public class AddBillingCommand : IRequest<Billing>
    {
        public int BookingId { get; }
        public int UserId { get; }
        public DateTime BillingDate { get; }
        public float TotalAmount { get; }
        public string PaymentMethod { get; }

        public AddBillingCommand(int bookingId, int userId, DateTime billingDate, float totalAmount, string paymentMethod)
        {
            BookingId = bookingId;
            UserId = userId;
            BillingDate = billingDate;
            TotalAmount = totalAmount;
            PaymentMethod = paymentMethod;
        }
    }
}
