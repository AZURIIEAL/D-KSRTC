using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusCategories.GetBusCategoryById
{
    public class GetBusCategoryByIdQuery : IRequest<BusCategory>
    {
        public int CategoryId { get; set; }
    }
}
