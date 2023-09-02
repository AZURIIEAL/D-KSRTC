using D_KSRTC.Models;
using D_KSRTC.Repositories.Times;
using MediatR;

namespace D_KSRTC.Requests.Commands.Times.AddTime
{
    public class AddTimeCommandHandler : IRequestHandler<AddTimeCommand, Time>
    {
        private readonly ITimeRepository _timeRepository;

        public AddTimeCommandHandler(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<Time> Handle(AddTimeCommand command, CancellationToken cancellationToken)
        {
            var time = new Time
            {
                BusTime = command.BusTime
            };

            return await _timeRepository.AddTimeAsync(time);
        }
    }
}
