using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Payments.AddPayment;
using D_KSRTC.Requests.Commands.Payments.DeletePayment;
using D_KSRTC.Requests.Commands.Payments.UpdatePayment;
using D_KSRTC.Requests.Queries.Payments.GetAllPayments;
using D_KSRTC.Requests.Queries.Payments.GetPaymentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Payment>> AddPaymentAsync(AddPaymentCommand payment, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new AddPaymentCommand(payment.BookingId, payment.Amount, payment.PaymentDate, payment.PaymentStatus), cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{paymentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Payment>> GetPaymentByIdAsync(int paymentId, CancellationToken cancellationToken = default)
        {
            try
            {
                var payment = await _mediator.Send(new GetPaymentByIdQuery( paymentId ), cancellationToken);

                if (payment == null)
                {
                    return NotFound();
                }

                return Ok(payment);
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
        public async Task<ActionResult<List<Payment>>> GetPaymentsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var payments = await _mediator.Send(new GetAllPaymentsQuery(), cancellationToken);

                if (payments == null)
                {
                    return NoContent();
                }

                return Ok(payments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        [Route("{paymentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePaymentAsync(int paymentId, UpdatePaymentCommand command, CancellationToken cancellationToken = default)
        {
            if (paymentId != command.PaymentId)
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
        [Route("{paymentId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePaymentAsync(int paymentId)
        {
            try
            {
                var result = await _mediator.Send(new DeletePaymentCommand(paymentId));

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