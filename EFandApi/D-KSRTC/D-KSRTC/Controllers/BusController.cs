using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Buses.AddBus;
using D_KSRTC.Requests.Commands.Buses.DeleteBus;
using D_KSRTC.Requests.Commands.Buses.UpdateBus;
using D_KSRTC.Requests.Queries.Buses.GetAllBuses;
using D_KSRTC.Requests.Queries.Buses.GetBusById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bus>> AddBusAsync(Bus bus, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new AddBusCommand
                {
                    BusName = bus.BusName,
                    TCId = bus.TCId,
                    TotalSeats = bus.TotalSeats
                }, cancellationToken);

                return CreatedAtAction(nameof(GetBusByIdAsync), new { busId = result.BusId }, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{busId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Bus>> GetBusByIdAsync(int busId, CancellationToken cancellationToken = default)
        {
            try
            {
                var busDetails = await _mediator.Send(new GetBusByIdQuery { BusId = busId }, cancellationToken);

                if (busDetails == null)
                {
                    return NotFound();
                }

                return Ok(busDetails);
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
        public async Task<ActionResult<List<Bus>>> GetBusesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var busDetails = await _mediator.Send(new GetAllBusesQuery(), cancellationToken);

                if (busDetails == null)
                {
                    return NoContent();
                }

                return Ok(busDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        [Route("{busId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateBusAsync(int busId, UpdateBusCommand command, CancellationToken cancellationToken = default)
        {
            if (busId != command.BusId)
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
        [Route("{busId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBusAsync(int busId, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBusCommand { BusId = busId }, cancellationToken);

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