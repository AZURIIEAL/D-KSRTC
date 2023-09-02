using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Billings.GetBillingById
{
    public class GetBillingByIdQuery : IRequest<Billing>
    {
        public int BillingId { get; set; }

        public GetBillingByIdQuery(int billingId)
        {
            BillingId = billingId;
        }
    }
}
