using D_KSRTC.Models;
using D_KSRTC.Repositories.Payments;
using MediatR;

namespace D_KSRTC.Requests.Queries.Payments.GetAllPayments
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<Payment>>
    {
        private readonly IPaymentRepository _paymentRepository;

        public GetAllPaymentsQueryHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<List<Payment>> Handle(GetAllPaymentsQuery query, CancellationToken cancellationToken)
        {
            return await _paymentRepository.GetAllPaymentsAsync();
        }
    }
}
