using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.RouteDetails.DeleteRouteDetails;
using D_KSRTC.Requests.Commands.RouteDetails.UpdateRouteDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RouteDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RouteDetails>> AddRouteDetailsAsync(AddRouteDetailsCommand routeDetails, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new AddRouteDetailsCommand
                {
                    RouteId = routeDetails.RouteId,
                    StopId = routeDetails.StopId,
                    Sequence = routeDetails.Sequence,
                    Distance = routeDetails.Distance,
                    Duration = routeDetails.Duration
                }, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{RDId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RouteDetails>> GetRouteDetailsByIdAsync(int RDId, CancellationToken cancellationToken = default)
        {
            try
            {
                var routeDetails = await _mediator.Send(new GetRouteDetailsByIdQuery { RDId = RDId }, cancellationToken);

                if (routeDetails == null)
                {
                    return NotFound();
                }

                return Ok(routeDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<RouteDetails>>> GetAllRouteDetailsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var routeDetails = await _mediator.Send(new GetAllRouteDetailsQuery(), cancellationToken);

                if (routeDetails == null)
                {
                    return NoContent();
                }

                return Ok(routeDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        [Route("{RDId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateRouteDetailsAsync(int RDId, RouteDetails routeDetails, CancellationToken cancellationToken = default)
        {
            if (RDId != routeDetails.RDId)
            {
                return BadRequest("ID mismatch between URL and request body.");
            }

            try
            {
                var result = await _mediator.Send(new UpdateRouteDetailsCommand
                {
                    RDId = RDId,
                    RouteId = routeDetails.RouteId,
                    StopId = routeDetails.StopId,
                    Sequence = routeDetails.Sequence,
                    Distance = routeDetails.Distance,
                    Duration = routeDetails.Duration
                }, cancellationToken);

                if (result == 1)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete]
        [Route("{RDId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteRouteDetailsAsync(int RDId, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new DeleteRouteDetailsCommand { RDId = RDId }, cancellationToken);

                if (result == 1)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}
