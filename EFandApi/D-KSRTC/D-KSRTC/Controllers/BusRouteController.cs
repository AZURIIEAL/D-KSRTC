using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.BusRoutes.AddBusRouteCommand;
using D_KSRTC.Requests.Commands.BusRoutes.UpdateBusRoute;
using D_KSRTC.Requests.Commands.BusRoutes.DeleteBusRoute;
using D_KSRTC.Requests.Queries.BusRoutes.GetAllBusRoutes;
using D_KSRTC.Requests.Queries.BusRoutes.GetBusRouteById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusRouteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusRouteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BusRoute>> AddBusRouteAsync(AddBusRouteCommand busRoute, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new AddBusRouteCommand(busRoute.BusId, busRoute.RouteId, busRoute.TimeId,busRoute.RouteDate), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{busRouteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BusRoute>> GetBusRouteByIdAsync(int busRouteId, CancellationToken cancellationToken = default)
        {
            try
            {
                var busRoute = await _mediator.Send(new GetBusRouteByIdQuery(busRouteId), cancellationToken);

                if (busRoute == null)
                {
                    return NotFound();
                }

                return Ok(busRoute);
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
        public async Task<ActionResult<List<BusRoute>>> GetBusRoutesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var busRoutes = await _mediator.Send(new GetAllBusRoutesQuery(), cancellationToken);

                if (busRoutes == null || busRoutes.Count == 0)
                {
                    return NoContent();
                }

                return Ok(busRoutes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateBusRouteAsync(int id, UpdateBusRouteCommand command, CancellationToken cancellationToken = default)
        {
            if (id != command.BusRouteId)
            {
                return BadRequest("ID mismatch between URL and request body.");
            }

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                if (result == 1)
                {
                    return Ok("Updated");
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
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBusRouteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBusRouteCommand(id), cancellationToken);

                if (result == 1)
                {
                    return Ok("Deleted");
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
