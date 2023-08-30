using D_KSRTC.Models;
using MediatR;

namespace D_KSRTC.Requests.Commands.Location.AddLocation
{
    public class AddLocationCommand : IRequest<LocationDetails>
    {
        public string LocationName { get; set; } = string.Empty;
        public AddLocationCommand(string locationName)
        {
            LocationName = locationName;
        }
    }
}
