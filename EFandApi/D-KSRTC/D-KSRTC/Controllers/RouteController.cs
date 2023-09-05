using D_KSRTC.Requests.Commands.Routes.AddRoute;
using D_KSRTC.Requests.Commands.Routes.DeleteRoute;
using D_KSRTC.Requests.Commands.Routes.UpdateRoute;
using D_KSRTC.Requests.Queries.Routes.GetAllRoutes;
using D_KSRTC.Requests.Queries.Routes.GetRouteById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RouteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Models.Route>> AddRouteAsync(AddRouteCommand route, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new AddRouteCommand(route.RouteName, route.SLId, route.ELId, route.Distance, route.Duration), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{RouteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Models.Route>> GetRouteByIdAsync(int RouteId, CancellationToken cancellationToken = default)
        {
            try
            {
                var route = await _mediator.Send(new GetRouteByIdQuery { RouteId = RouteId }, cancellationToken);

                if (route == null)
                {
                    return NotFound();
                }

                return Ok(route);
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
        public async Task<ActionResult<List<Models.Route>>> GetRoutesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var routes = await _mediator.Send(new GetAllRoutesQuery(), cancellationToken);

                if (routes == null)
                {
                    return NoContent();
                }

                return Ok(routes);
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
        public async Task<ActionResult> UpdateRouteAsync(int id, UpdateRouteCommand command, CancellationToken cancellationToken = default)
        {
            if (id != command.RouteId)
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
        public async Task<ActionResult> DeleteRouteAsync(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteRouteCommand(id));

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