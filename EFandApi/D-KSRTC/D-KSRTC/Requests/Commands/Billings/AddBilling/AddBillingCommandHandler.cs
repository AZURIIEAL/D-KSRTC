using D_KSRTC.Models;
using D_KSRTC.Repositories.Billings;
using MediatR;

namespace D_KSRTC.Requests.Commands.Billings.AddBilling
{
    public class AddBillingCommandHandler : IRequestHandler<AddBillingCommand, Billing>
    {
        private readonly IBillingRepository _billingRepository;

        public AddBillingCommandHandler(IBillingRepository billingRepository)
        {
            _billingRepository = billingRepository;
        }

        public async Task<Billing> Handle(AddBillingCommand request, CancellationToken cancellationToken)
        {
            Billing billing = new Billing
            {
                BookingId = request.BookingId,
                UserId = request.UserId,
                BillingDate = request.BillingDate,
                TotalAmount = request.TotalAmount,
                PaymentMethod = request.PaymentMethod,
            };
        return await _billingRepository.AddBillingAsync(billing);
        }
    }
}
