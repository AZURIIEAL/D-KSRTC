using MediatR;

namespace D_KSRTC.Requests.Commands.Routes.DeleteRoute
{
    public class DeleteRouteCommand : IRequest<int>
    {
        private int id;
        public int RouteId { get; set; }

        public DeleteRouteCommand(int id)
        {
            this.id = id;
        }

       
    }

}
