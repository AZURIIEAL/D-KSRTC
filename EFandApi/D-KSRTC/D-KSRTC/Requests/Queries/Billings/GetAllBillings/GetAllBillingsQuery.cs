using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Billings.GetAllBillings
{
    public class GetAllBillingsQuery : IRequest<List<Billing>>
    {
    }
}
