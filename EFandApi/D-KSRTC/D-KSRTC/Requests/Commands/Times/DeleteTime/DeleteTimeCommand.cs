using MediatR;

namespace D_KSRTC.Requests.Commands.Times.DeleteTime
{
    public class DeleteTimeCommand : IRequest<int>
    {
        public int TimeId { get; set; }

        public DeleteTimeCommand(int timeId)
        {
            TimeId = timeId;
        }
    }
}
