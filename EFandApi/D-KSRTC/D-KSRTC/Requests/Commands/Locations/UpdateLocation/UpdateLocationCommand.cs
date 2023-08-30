using MediatR;

namespace D_KSRTC.Requests.Commands.Location.UpdateLocation
{
    public class UpdateLocationCommand :IRequest<int>
    {
        public int Id { get; set; }
        public string LocationName { get; set; }  = string.Empty;
       
    }

}
