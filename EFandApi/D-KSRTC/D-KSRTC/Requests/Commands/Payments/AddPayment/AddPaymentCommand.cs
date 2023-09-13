using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Payments.AddPayment
{
    public class AddPaymentCommand : IRequest<Payment>
    {
        public int BookingId { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }

        public AddPaymentCommand()
        {
                
        }
        public AddPaymentCommand(int bookingId, float amount, DateTime paymentDate, string paymentStatus)
        {
            BookingId = bookingId;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentStatus = paymentStatus;
        }
    }
}
