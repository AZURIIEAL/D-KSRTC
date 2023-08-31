using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusTypeCategories.GetBusTypeCategoryById
{
    public class GetBusTypeCategoryByIdQuery : IRequest<BusTypeCategory>
    {
        public int TCId { get; set; }
    }
}
