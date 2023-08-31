using D_KSRTC.Repositories.BusCategories;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusCategories.UpdateBusCategory
{
    public class UpdateBusCategoryCommandHandler : IRequestHandler<UpdateBusCategoryCommand, int>
    {
        private readonly IBusCategoryRepository _busCategoryRepository;

        public UpdateBusCategoryCommandHandler(IBusCategoryRepository busCategoryRepository)
        {
            _busCategoryRepository = busCategoryRepository;
        }

        public async Task<int> Handle(UpdateBusCategoryCommand command, CancellationToken cancellationToken)
        {
            var categoryDetails = await _busCategoryRepository.GetBusCategoryByIdAsync(command.CategoryId);
            if (categoryDetails == null)
            {
                throw new ArgumentException($"Bus category with ID {command.CategoryId} not found.");
            }

            categoryDetails.CategoryName = command.CategoryName;
            categoryDetails.BaseFare = command.BaseFare;

            await _busCategoryRepository.UpdateBusCategoryAsync(categoryDetails);

            return 1;
        }
    }
}
