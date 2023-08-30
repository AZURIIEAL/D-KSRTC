using D_KSRTC.Models;
using D_KSRTC.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<LocationDetails>> GetLocationsAsync(CancellationToken cancellationToken = default)
        {
            var locationDetails = await _mediator.Send(new GetAllLocationsQuery(), cancellationToken);

            return locationDetails;
        }



    }
}
