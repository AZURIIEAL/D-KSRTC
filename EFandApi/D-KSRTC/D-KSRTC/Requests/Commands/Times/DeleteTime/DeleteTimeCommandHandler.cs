using D_KSRTC.Repositories.Times;
using MediatR;

namespace D_KSRTC.Requests.Commands.Times.DeleteTime
{
    public class DeleteTimeCommandHandler : IRequestHandler<DeleteTimeCommand, int>
    {
        private readonly ITimeRepository _timeRepository;

        public DeleteTimeCommandHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<int> Handle(DeleteTimeCommand command, CancellationToken cancellationToken)
        {
            return await _timeRepository.DeleteTimeAsync(command.TimeId);
        }
    }
}
