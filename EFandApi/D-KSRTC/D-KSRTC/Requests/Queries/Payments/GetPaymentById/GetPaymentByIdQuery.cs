using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Payments.GetPaymentById
{
    public class GetPaymentByIdQuery : IRequest<Payment>
    {
        public int PaymentId { get; set; }

        public GetPaymentByIdQuery(int paymentId)
        {
            PaymentId = paymentId;
        }
    }
}
