using D_KSRTC.Models;
using D_KSRTC.Repositories.BusCategories;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusCategories.GetBusCategoryById
{
    public class GetBusCategoryByIdQueryHandler : IRequestHandler<GetBusCategoryByIdQuery, BusCategory>
    {
        private readonly IBusCategoryRepository _busCategoryRepository;

        public GetBusCategoryByIdQueryHandler(IBusCategoryRepository busCategoryRepository)
        {
            _busCategoryRepository = busCategoryRepository;
        }

        public async Task<BusCategory> Handle(GetBusCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var categoryDetails = await _busCategoryRepository.GetBusCategoryByIdAsync(query.CategoryId);
            if (categoryDetails == null)
            {
                throw new ArgumentException($"Bus category with ID {query.CategoryId} not found.");
            }
            return categoryDetails;
        }
    }
}
