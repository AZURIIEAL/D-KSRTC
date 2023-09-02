using D_KSRTC.Repositories.Times;
using MediatR;

namespace D_KSRTC.Requests.Commands.Times.UpdateTime
{
    public class UpdateTimeCommandHandler : IRequestHandler<UpdateTimeCommand, int>
    {
        private readonly ITimeRepository _timeRepository;

        public UpdateTimeCommandHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<int> Handle(UpdateTimeCommand command, CancellationToken cancellationToken)
        {
            var time = await _timeRepository.GetTimeByIdAsync(command.TimeId);

            if (time == null)
            {
                return default; // Time not found
            }

            time.BusTime = command.BusTime;
            return await _timeRepository.UpdateTimeAsync(time);
        }
    }
}
