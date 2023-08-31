using D_KSRTC.Models;
using D_KSRTC.Repositories.BusTypeCategories;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusTypeCategories.GetAllBusTypeCategory
{
    public class GetAllBusTypeCategoriesQueryHandler : IRequestHandler<GetAllBusTypeCategoriesQuery, List<BusTypeCategory>>
    {
        private readonly IBusTypeCategoryRepository _busTypeCategoryRepository;

        public GetAllBusTypeCategoriesQueryHandler(IBusTypeCategoryRepository busTypeCategoryRepository)
        {
            _busTypeCategoryRepository = busTypeCategoryRepository;
        }

        public async Task<List<BusTypeCategory>> Handle(GetAllBusTypeCategoriesQuery query, CancellationToken cancellationToken)
        {
            return await _busTypeCategoryRepository.GetAllBusTypeCategoryAsync();
        }
    }
}
