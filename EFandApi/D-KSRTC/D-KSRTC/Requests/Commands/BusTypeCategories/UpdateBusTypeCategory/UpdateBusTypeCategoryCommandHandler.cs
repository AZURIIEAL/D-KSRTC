using D_KSRTC.Repositories.BusTypeCategories;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypeCategories.UpdateBusTypeCategory
{
    public class UpdateBusTypeCategoryCommandHandler : IRequestHandler<UpdateBusTypeCategoryCommand, int>
    {
        private readonly IBusTypeCategoryRepository _busTypeCategoryRepository;

        public UpdateBusTypeCategoryCommandHandler(IBusTypeCategoryRepository busTypeCategoryRepository)
        {
            _busTypeCategoryRepository = busTypeCategoryRepository;
        }

        public async Task<int> Handle(UpdateBusTypeCategoryCommand command, CancellationToken cancellationToken)
        {
            var tcDetails = await _busTypeCategoryRepository.GetBusTypeCategoryByIdAsync(command.TCId);
            if (tcDetails == null)
            {
                throw new FileNotFoundException($"Bus type category with ID {command.TCId} not found.");
            }

            tcDetails.CategoryId = command.CategoryId;
            tcDetails.TypeId = command.TypeId;

            await _busTypeCategoryRepository.UpdateBusTypeCategoryAsync(tcDetails);
            return 1; // Return 1 to indicate success.
        }
    }
}
