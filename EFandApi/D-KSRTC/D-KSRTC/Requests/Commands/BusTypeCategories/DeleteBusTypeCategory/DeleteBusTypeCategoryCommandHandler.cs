using D_KSRTC.Repositories.BusTypeCategories;
using MediatR;

namespace D_KSRTC.Requests.Commands.BusTypeCategories.DeleteBusTypeCategory
{
    public class DeleteBusTypeCategoryCommandHandler : IRequestHandler<DeleteBusTypeCategoryCommand, int>
    {
        private readonly IBusTypeCategoryRepository _busTypeCategoryRepository;

        public DeleteBusTypeCategoryCommandHandler(IBusTypeCategoryRepository busTypeCategoryRepository)
        {
            _busTypeCategoryRepository = busTypeCategoryRepository;
        }

        public async Task<int> Handle(DeleteBusTypeCategoryCommand command, CancellationToken cancellationToken)
        {
            var tcDetails = await _busTypeCategoryRepository.DeleteBusTypeCategoryAsync(command.TCId);
            if (tcDetails == null)
            {
                return default;
            }
            return 1;
        }
    }
}
