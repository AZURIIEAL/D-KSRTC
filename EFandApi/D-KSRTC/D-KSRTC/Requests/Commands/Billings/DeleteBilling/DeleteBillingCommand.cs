using MediatR;

namespace D_KSRTC.Requests.Commands.Billings.DeleteBilling
{
    public class DeleteBillingCommand : IRequest<int>
    {
        public int BillingId { get; set; }

        public DeleteBillingCommand(int billingId)
        {
            BillingId = billingId;
        }
    }
}
