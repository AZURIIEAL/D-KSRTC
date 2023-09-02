using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Billings.UpdateBilling
{
    public class UpdateBillingCommand : IRequest<int>
    {
        public int BillingId { get; set; }
        public Billing Billing { get; set; }

        public UpdateBillingCommand(int billingId, Billing billing)
        {
            BillingId = billingId;
            Billing = billing;
        }
    }
}
