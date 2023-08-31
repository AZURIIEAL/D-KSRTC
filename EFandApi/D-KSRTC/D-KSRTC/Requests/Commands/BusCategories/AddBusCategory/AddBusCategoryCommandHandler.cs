using D_KSRTC.Models;
using D_KSRTC.Repositories.BusCategories;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusCategories.AddBusCategory
{
    public class AddBusCategoryCommandHandler : IRequestHandler<AddBusCategoryCommand, BusCategory>
    {
        private readonly IBusCategoryRepository _busCategoryRepository;

        public AddBusCategoryCommandHandler(IBusCategoryRepository busCategoryRepository)
        {
            _busCategoryRepository = busCategoryRepository;
        }

        public async Task<BusCategory> Handle(AddBusCategoryCommand command, CancellationToken cancellationToken)
        {
            var categoryDetails = new BusCategory
            {
                CategoryName = command.CategoryName,
                BaseFare = command.BaseFare
            };

            return await _busCategoryRepository.AddBusCategoryAsync(categoryDetails);
        }
    }
}
