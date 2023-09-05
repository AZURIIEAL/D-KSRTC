using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.BusTypeCategories.AddBusTypeCategory;
using D_KSRTC.Requests.Commands.BusTypeCategories.DeleteBusTypeCategory;
using D_KSRTC.Requests.Commands.BusTypeCategories.UpdateBusTypeCategory;
using D_KSRTC.Requests.Queries.BusTypeCategories.GetAllBusTypeCategory;
using D_KSRTC.Requests.Queries.BusTypeCategories.GetBusTypeCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusTypeCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusTypeCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BusTypeCategory>> AddBusTypeCategoryAsync(AddBusTypeCategoryCommand tcDetails, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new AddBusTypeCategoryCommand(tcDetails.CategoryId, tcDetails.TypeId), cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{tcId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BusTypeCategory>> GetBusTypeCategoryByIdAsync(int tcId, CancellationToken cancellationToken = default)
        {
            try
            {
                var tcDetails = await _mediator.Send(new GetBusTypeCategoryByIdQuery { TCId = tcId }, cancellationToken);

                if (tcDetails == null)
                {
                    return NotFound();
                }

                return Ok(tcDetails);
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
        public async Task<ActionResult<List<BusTypeCategory>>> GetAllBusTypeCategoriesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var tcDetails = await _mediator.Send(new GetAllBusTypeCategoriesQuery(), cancellationToken);
                return Ok(tcDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        [Route("{tcId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateBusTypeCategoryAsync(int tcId, UpdateBusTypeCategoryCommand command, CancellationToken cancellationToken = default)
        {
            if (tcId != command.TCId)
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
        [Route("{tcId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBusTypeCategoryAsync(int tcId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBusTypeCategoryCommand { TCId = tcId });

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