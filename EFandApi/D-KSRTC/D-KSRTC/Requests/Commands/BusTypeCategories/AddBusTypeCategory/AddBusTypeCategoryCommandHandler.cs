using D_KSRTC.Models;
using D_KSRTC.Repositories.BusTypeCategories;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypeCategories.AddBusTypeCategory
{
    public class AddBusTypeCategoryCommandHandler : IRequestHandler<AddBusTypeCategoryCommand, BusTypeCategory>
    {
        private readonly IBusTypeCategoryRepository _busTypeCategoryRepository;

        public AddBusTypeCategoryCommandHandler(IBusTypeCategoryRepository busTypeCategoryRepository)
        {
            _busTypeCategoryRepository = busTypeCategoryRepository;
        }

        public async Task<BusTypeCategory> Handle(AddBusTypeCategoryCommand command, CancellationToken cancellationToken)
        {
            var tcDetails = new BusTypeCategory
            {
                CategoryId = command.CategoryId,
                TypeId = command.TypeId
            };

            return await _busTypeCategoryRepository.AddBusTypeCategoryAsync(tcDetails);
        }
    }
}
