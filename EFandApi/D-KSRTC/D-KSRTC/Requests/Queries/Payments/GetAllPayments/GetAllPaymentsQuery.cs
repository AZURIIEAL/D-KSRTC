using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.Payments.GetAllPayments
{
    public class GetAllPaymentsQuery : IRequest<List<Payment>>
    {
    }
}
