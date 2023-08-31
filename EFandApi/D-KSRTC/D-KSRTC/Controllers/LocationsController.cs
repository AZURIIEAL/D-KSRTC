using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Location.AddLocation;
using D_KSRTC.Requests.Commands.Location.UpdateLocation;
using D_KSRTC.Requests.Commands.Locations.DeleteLocation;
using D_KSRTC.Requests.Queries.Location.GetAllLocation;
using D_KSRTC.Requests.Queries.Location.GetLocationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<LocationDetails>>> GetLocationsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var locationDetails = await _mediator.Send(new GetAllLocationsQuery(), cancellationToken);
                if (locationDetails == null)
                {
                    return NoContent(); // 204 No Content
                }
                return Ok(locationDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        [HttpGet]
        [Route("{LocationId}")]
        [ProducesResponseType(StatusCodes.Status200OK)] 
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LocationDetails>> GetLocationByIdAsync(int LocationId, CancellationToken cancellationToken = default)
        {
            try
            {
                var locationDetails = await _mediator.Send(new GetLocationByIdQuery { Id = LocationId }, cancellationToken);

                if (locationDetails == null)
                {
                    return NotFound(); // Return 404 Not Found if locationDetails is null.
                }

                return Ok(locationDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Log the exception to the console.
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LocationDetails>> AddLocationAsync(LocationDetails location, CancellationToken cancellationToken = default)
        {
            try
            {
                // Assuming you have a command to add a location, replace with your actual command class
                var result = await _mediator.Send(new AddLocationCommand(location.LocationName), cancellationToken);

                // You can return a CreatedAtAction result with the created location and its ID
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Log the exception to the console.
                                       // Log the exception or perform any necessary error handling
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateLocationAsync(int id,UpdateLocationCommand command, CancellationToken cancellationToken = default)
        {
            if (id != command.Id)
            {
                //incase the person tried to alter the id.
                return BadRequest("ID mismatch between URL and request body.");
            }

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                if (result == 1)
                {
                    return NoContent(); // 204 No Content
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Log the exception to the console.
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteLocationAsync(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteLocationCommand { Id = id });

                if (result == 1)
                {
                    return NoContent(); // 204 No Content
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Log the exception to the console.
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

    }
}