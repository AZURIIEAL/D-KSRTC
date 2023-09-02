using D_KSRTC.Repositories.Billings;
using MediatR;

namespace D_KSRTC.Requests.Commands.Billings.DeleteBilling
{
    public class DeleteBillingCommandHandler : IRequestHandler<DeleteBillingCommand, int>
    {
        private readonly IBillingRepository _billingRepository;

        public DeleteBillingCommandHandler(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public async Task<int> Handle(DeleteBillingCommand request, CancellationToken cancellationToken)
        {
            return await _billingRepository.DeleteBillingAsync(request.BillingId);
        }
    }
}
