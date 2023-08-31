using D_KSRTC.Models;
using D_KSRTC.Repositories.BusTypeCategories;
using MediatR;

namespace D_KSRTC.Requests.Queries.BusTypeCategories.GetBusTypeCategoryById
{
    public class GetBusTypeCategoryByIdQueryHandler : IRequestHandler<GetBusTypeCategoryByIdQuery, BusTypeCategory>
    {
        private readonly IBusTypeCategoryRepository _busTypeCategoryRepository;

        public GetBusTypeCategoryByIdQueryHandler(IBusTypeCategoryRepository busTypeCategoryRepository)
        {
            _busTypeCategoryRepository = busTypeCategoryRepository;
        }

        public async Task<BusTypeCategory> Handle(GetBusTypeCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var tcDetails = await _busTypeCategoryRepository.GetBusTypeCategoryByIdAsync(query.TCId);
            if (tcDetails == null)
            {
                throw new FileNotFoundException($"Bus type category with ID {query.TCId} not found.");
            }
            return tcDetails;
        }
    }
}
