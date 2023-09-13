using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Seats.AddSeat;
using D_KSRTC.Requests.Commands.Seats.DeleteSeat;
using D_KSRTC.Requests.Commands.Seats.PatchSeatAvailability;
using D_KSRTC.Requests.Commands.Seats.UpdateSeat;
using D_KSRTC.Requests.Queries.Seats.GetAllSeats;
using D_KSRTC.Requests.Queries.Seats.GetSeatAvailability;
using D_KSRTC.Requests.Queries.Seats.GetSeatById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Seat>> AddSeatAsync(AddSeatCommand command, CancellationToken cancellationToken = default)
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
        [Route("{SeatID}")]
        [ProducesResponseType(typeof(Seat), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Seat>> GetSeatByIdAsync(int SeatID, CancellationToken cancellationToken = default)
        {
            try
            {
                var seat = await _mediator.Send(new GetSeatByIdQuery { SeatID = SeatID }, cancellationToken);

                if (seat == null)
                {
                    return NotFound();
                }

                return Ok(seat);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }


        [HttpGet]
        [Route("seat-availability")]
        [ProducesResponseType(typeof(Seat), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Seat>>> GetSeatAvailabilityAsync([FromQuery] GetSeatAvailabilityQuery request, CancellationToken cancellationToken = default)
        {
            try
            {
                var seat = await _mediator.Send(request, cancellationToken);

                if (seat == null)
                {
                    return NotFound();
                }

                return Ok(seat);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }




        [HttpGet]
        [ProducesResponseType(typeof(List<Seat>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Seat>>> GetAllSeatsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var seats = await _mediator.Send(new GetAllSeatsQuery(), cancellationToken);

                if (seats == null)
                {
                    return NoContent();
                }

                return Ok(seats);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        [Route("{SeatID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateSeatAsync(int SeatID, UpdateSeatCommand command, CancellationToken cancellationToken = default)
        {
            if (SeatID != command.SeatID)
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
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }


        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateSeatAvailability(PatchSeatAvailabilityCommand command, CancellationToken cancellationToken = default)
        {

            try
            {
                var result = await _mediator.Send(command, cancellationToken);

                if (result == 1)
                {
                    return Ok(result);
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
        [Route("{SeatID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteSeatAsync(int SeatID, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new DeleteSeatCommand { SeatID = SeatID }, cancellationToken);

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