using D_KSRTC.Models;
using D_KSRTC.Repositories.Billings;
using MediatR;

namespace D_KSRTC.Requests.Queries.Billings.GetBillingById
{
    public class GetBillingByIdQueryHandler : IRequestHandler<GetBillingByIdQuery, Billing>
    {
        private readonly IBillingRepository _billingRepository;

        public GetBillingByIdQueryHandler(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public async Task<Billing> Handle(GetBillingByIdQuery request, CancellationToken cancellationToken)
        {
            var billingDetails = await _billingRepository.GetBillingByIdAsync(request.BillingId);
            return billingDetails ?? new Billing();
        }
    }
}
