using D_KSRTC.Models;
using D_KSRTC.Repositories.Billings;
using MediatR;

namespace D_KSRTC.Requests.Queries.Billings.GetAllBillings
{
    public class GetAllBillingsQueryHandler : IRequestHandler<GetAllBillingsQuery, List<Billing>>
    {
        private readonly IBillingRepository _billingRepository;

        public GetAllBillingsQueryHandler(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public async Task<List<Billing>> Handle(GetAllBillingsQuery request, CancellationToken cancellationToken)
        {
            return await _billingRepository.GetAllBillingsAsync();
        }
    }
}
