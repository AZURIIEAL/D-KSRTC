using D_KSRTC.Models;
using D_KSRTC.Repositories.BusCategories;
using MediatR;
using static D_KSRTC.Requests.Queries.BusCategories.GetAllBusCategory.GetAllBusCategoryQuery;

namespace D_KSRTC.Requests.Queries.BusCategories.GetAllBusCategory
{
    public class GetAllBusCategoriesQueryHandler : IRequestHandler<GetAllBusCategoriesQuery, List<BusCategory>>
    {
        private readonly IBusCategoryRepository _busCategoryRepository;

        public GetAllBusCategoriesQueryHandler(IBusCategoryRepository busCategoryRepository)
        {
            _busCategoryRepository = busCategoryRepository;
        }

        public async Task<List<BusCategory>> Handle(GetAllBusCategoriesQuery query, CancellationToken cancellationToken)
        {
            return await _busCategoryRepository.GetAllBusCategoryAsync();
        }
    }
}
