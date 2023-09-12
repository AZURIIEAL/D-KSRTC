using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Bookings.CreateBooking;
using D_KSRTC.Requests.Commands.Bookings.DeleteBooking;
using D_KSRTC.Requests.Commands.Bookings.UpdateBooking;
using D_KSRTC.Requests.Queries.Bookings.GetAllBookings;
using D_KSRTC.Requests.Queries.Bookings.GetBookingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Booking>> CreateBookingAsync(CreateBookingCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(command, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Booking>> GetBookingByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var booking = await _mediator.Send(new GetBookingByIdQuery { BookingId = id }, cancellationToken);
                if (booking == null)
                {
                    return NotFound();
                }
                return Ok(booking);
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
        public async Task<ActionResult<List<Booking>>> GetAllBookingsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var bookings = await _mediator.Send(new GetAllBookingsQuery(), cancellationToken);
                if (bookings == null)
                {
                    return NoContent();
                }
                return Ok(bookings);
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
        public async Task<ActionResult> UpdateBookingAsync(int id, UpdateBookingCommand command, CancellationToken cancellationToken = default)
        {
            if (id != command.BookingId)
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
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBookingAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBookingCommand { BookingId = id }, cancellationToken);

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
