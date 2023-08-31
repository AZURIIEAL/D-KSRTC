using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusCategories.GetAllBusCategory
{
    public class GetAllBusCategoryQuery
    {
        public class GetAllBusCategoriesQuery : IRequest<List<BusCategory>>
        {
        }
    }
}
