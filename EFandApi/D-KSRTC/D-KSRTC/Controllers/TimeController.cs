using D_KSRTC.Models;
using D_KSRTC.Requests.Queries.Times.GetAllTimes;
using D_KSRTC.Requests.Queries.Times.GetTimeById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Time>>> GetAllTimesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var times = await _mediator.Send(new GetAllTimesQuery(), cancellationToken);

                if (times == null)
                {
                    return NoContent();
                }

                return Ok(times);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{timeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Time>> GetTimeByIdAsync(int timeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var time = await _mediator.Send(new GetTimeByIdQuery(timeId), cancellationToken);

                if (time == null)
                {
                    return NotFound();
                }

                return Ok(time);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}