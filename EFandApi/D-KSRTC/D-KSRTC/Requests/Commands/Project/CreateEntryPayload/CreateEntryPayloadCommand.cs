using D_KSRTC.DTO_s;
using MediatR;

namespace D_KSRTC.Requests.Commands.Project.CreateEntryPayload
{
    public class CreateEntryPayloadCommand:IRequest<bool>
    {
        public PayloadDTO? payload { get; set; }
        public CreateEntryPayloadCommand()
        {
            
        }
    }
}
