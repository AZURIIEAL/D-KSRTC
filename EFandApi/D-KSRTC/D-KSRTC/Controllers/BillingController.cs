using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Billings.AddBilling;
using D_KSRTC.Requests.Commands.Billings.DeleteBilling;
using D_KSRTC.Requests.Commands.Billings.UpdateBilling;
using D_KSRTC.Requests.Queries.Billings.GetAllBillings;
using D_KSRTC.Requests.Queries.Billings.GetBillingById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BillingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Billing>> AddBillingAsync(Billing billing, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new AddBillingCommand(billing.BookingId, billing.UserId, billing.BillingDate, billing.TotalAmount, billing.PaymentMethod), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{BillingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Billing>> GetBillingByIdAsync(int BillingId, CancellationToken cancellationToken = default)
        {
            try
            {
                var billing = await _mediator.Send(new GetBillingByIdQuery( BillingId ), cancellationToken);

                if (billing == null)
                {
                    return NotFound();
                }

                return Ok(billing);
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
        public async Task<ActionResult<List<Billing>>> GetBillingsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var billings = await _mediator.Send(new GetAllBillingsQuery(), cancellationToken);

                if (billings == null)
                {
                    return NoContent();
                }

                return Ok(billings);
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
        public async Task<ActionResult> UpdateBillingAsync(int id, UpdateBillingCommand command, CancellationToken cancellationToken = default)
        {
            if (id != command.BillingId)
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
        public async Task<ActionResult> DeleteBillingAsync(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBillingCommand( id ));

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