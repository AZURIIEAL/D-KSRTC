using D_KSRTC.Models;
using D_KSRTC.Requests.Queries.Location.GetAllLocation;
using D_KSRTC.Requests.Queries.Location.GetLocationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        //Setting up mediator
        private readonly IMediator _mediator;
        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Adding the get alldata api
        [HttpGet]
        public async Task<ActionResult<List<LocationDetails>>> GetLocationsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var locationDetails = await _mediator.Send(new GetAllLocationsQuery(), cancellationToken);
                return locationDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{LocationId}")]
        public async Task<ActionResult<LocationDetails>> GetLocationByIdAsync(int LocationId)
        {
            try
            {
                var locationDetails = await _mediator.Send(new GetLocationByIdQuery { Id = LocationId });

                if (locationDetails == null)
                {
                    return NotFound(); // Return 404 Not Found if locationDetails is null.
                }

                return locationDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Log the exception to the console.
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }





    }
}
