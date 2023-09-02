using D_KSRTC.Repositories.Billings;
using MediatR;

namespace D_KSRTC.Requests.Commands.Billings.UpdateBilling
{
    public class UpdateBillingCommandHandler : IRequestHandler<UpdateBillingCommand, int>
    {
        private readonly IBillingRepository _billingRepository;

        public UpdateBillingCommandHandler(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public async Task<int> Handle(UpdateBillingCommand request, CancellationToken cancellationToken)
        {
            request.Billing.BillingId = request.BillingId;
            return await _billingRepository.UpdateBillingAsync(request.Billing);
        }
    }
}
