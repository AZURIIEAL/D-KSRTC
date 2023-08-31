using D_KSRTC.Repositories.BusCategories;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusCategories.DeleteBusCategory
{
    public class DeleteBusCategoryCommandHandler : IRequestHandler<DeleteBusCategoryCommand, int>
    {
        private readonly IBusCategoryRepository _busCategoryRepository;

        public DeleteBusCategoryCommandHandler(IBusCategoryRepository busCategoryRepository)
        {
            _busCategoryRepository = busCategoryRepository;
        }

        public async Task<int> Handle(DeleteBusCategoryCommand command, CancellationToken cancellationToken)
        {
            var deletedCategory = await _busCategoryRepository.DeleteBusCategoryAsync(command.CategoryId);
            return deletedCategory != null ? 1 : 0;
        }
    }
}
