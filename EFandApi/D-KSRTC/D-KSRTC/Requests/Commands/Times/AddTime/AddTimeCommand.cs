using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Times.AddTime
{
    public class AddTimeCommand : IRequest<Time>
    {
        public DateTime BusTime { get; set; }

        public AddTimeCommand(DateTime busTime)
        {
            BusTime = busTime;
        }
    }
}
