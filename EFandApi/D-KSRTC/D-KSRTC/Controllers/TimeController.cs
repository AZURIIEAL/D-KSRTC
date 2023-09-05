using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Times.AddTime;
using D_KSRTC.Requests.Commands.Times.DeleteTime;
using D_KSRTC.Requests.Commands.Times.UpdateTime;
using D_KSRTC.Requests.Queries.Times.GetAllTimes;
using D_KSRTC.Requests.Queries.Times.GetTimeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpPost]
        [ProducesResponseType(typeof(Time), (int)HttpStatusCode.Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Time>> AddTimeAsync(AddTimeCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                return Ok(result);
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
        [HttpPut]
        [Route("{timeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateSeatAsync(int timeId, UpdateTimeCommand command, CancellationToken cancellationToken = default)
        {
            if (timeId != command.TimeId)
            {
                return BadRequest("ID mismatch between URL and request body.");
            }

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                if (result == 1)
                {
                    return NoContent();
                }
                else if (result == -1)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("Failed to update the seat.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete]
        [Route("{timeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteSeatAsync(int timeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new DeleteTimeCommand ( timeId ), cancellationToken);

                if (result == 1)
                {
                    return NoContent();
                }
                else if (result == -1)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("Failed to delete the seat.");
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