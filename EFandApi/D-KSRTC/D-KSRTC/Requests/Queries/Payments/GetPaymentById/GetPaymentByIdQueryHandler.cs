using D_KSRTC.Models;
using D_KSRTC.Repositories.Payments;
using MediatR;

namespace D_KSRTC.Requests.Queries.Payments.GetPaymentById
{
    public class GetPaymentByIdQueryHandler : IRequestHandler<GetPaymentByIdQuery, Payment>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentByIdQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> Handle(GetPaymentByIdQuery query, CancellationToken cancellationToken)
        {
            Payment? paymentDetails = await _paymentRepository.GetPaymentByIdAsync(query.PaymentId);
            return paymentDetails ?? new Payment();
        }
    }
}
