using MediatR;

namespace D_KSRTC.Requests.Commands.Times.UpdateTime
{
    public class UpdateTimeCommand : IRequest<int>
    {
        public int TimeId { get; set; }
        public DateTime BusTime { get; set; }

        public UpdateTimeCommand(int timeId, DateTime busTime)
        {
            TimeId = timeId;
            BusTime = busTime;
        }
    }
}
