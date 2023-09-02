using MediatR;

namespace D_KSRTC.Requests.Commands.Payments.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest<int>
    {
        public int PaymentId { get; set; }
        public int BookingId { get; set; }
        public float Amount { get; set; }
        public string PaymentStatus { get; set; }

        public UpdatePaymentCommand(int paymentId, int bookingId, float amount, string paymentStatus)
        {
            PaymentId = paymentId;
            BookingId = bookingId;
            Amount = amount;
            PaymentStatus = paymentStatus;
        }
    }
}
