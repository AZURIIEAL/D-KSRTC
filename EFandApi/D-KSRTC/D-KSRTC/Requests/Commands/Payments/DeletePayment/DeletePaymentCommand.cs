using MediatR;

namespace D_KSRTC.Requests.Commands.Payments.DeletePayment
{
    public class DeletePaymentCommand : IRequest<int>
    {
        public int PaymentId { get; set; }

        public DeletePaymentCommand(int paymentId)
        {
            PaymentId = paymentId;
        }
    }
}
