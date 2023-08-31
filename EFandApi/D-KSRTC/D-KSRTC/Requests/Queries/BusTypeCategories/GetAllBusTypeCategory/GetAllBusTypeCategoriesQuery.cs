using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusTypeCategories.GetAllBusTypeCategory
{
    public class GetAllBusTypeCategoriesQuery : IRequest<List<BusTypeCategory>>
    {
    }
}
