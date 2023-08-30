using MediatR;

namespace D_KSRTC.Requests.Commands.Locations.DeleteLocation
{
    public class DeleteLocationCommand :IRequest<int>
    {
        public int Id { get; set; }

    }
}
