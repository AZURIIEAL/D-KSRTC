using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Passengers.AddPassenger;
using D_KSRTC.Requests.Commands.Passengers.DeletePassenger;
using D_KSRTC.Requests.Commands.Passengers.UpdatePassenger;
using D_KSRTC.Requests.Queries.Passengers.GetAllPassengers;
using D_KSRTC.Requests.Queries.Passengers.GetPassengerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PassengerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Passenger>> AddPassengerAsync(AddPassengerCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Log the exception to the console.
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{passengerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Passenger>> GetPassengerByIdAsync(int passengerId, CancellationToken cancellationToken = default)
        {
            try
            {
                var passenger = await _mediator.Send(new GetPassengerByIdQuery(passengerId), cancellationToken);

                if (passenger == null)
                {
                    return NotFound();
                }

                return Ok(passenger);
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
        public async Task<ActionResult<List<Passenger>>> GetPassengersAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var passengers = await _mediator.Send(new GetAllPassengersQuery(), cancellationToken);

                if (passengers == null)
                {
                    return NoContent();
                }

                return Ok(passengers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        [Route("{passengerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePassengerAsync(int passengerId, UpdatePassengerCommand passenger, CancellationToken cancellationToken = default)
        {
            if (passengerId != passenger.PassengerId)
            {
                return BadRequest("ID mismatch between URL and request body.");
            }

            try
            {
                var result = await _mediator.Send(passenger, cancellationToken);

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
        [Route("{passengerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePassengerAsync(int passengerId, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new DeletePassengerCommand(passengerId), cancellationToken);

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