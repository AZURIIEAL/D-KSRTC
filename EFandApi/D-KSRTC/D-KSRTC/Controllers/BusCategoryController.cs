using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.BusCategories.AddBusCategory;
using D_KSRTC.Requests.Commands.BusCategories.DeleteBusCategory;
using D_KSRTC.Requests.Commands.BusCategories.UpdateBusCategory;
using D_KSRTC.Requests.Queries.BusCategories.GetBusCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static D_KSRTC.Requests.Queries.BusCategories.GetAllBusCategory.GetAllBusCategoryQuery;


namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BusCategory>> AddBusCategoryAsync(BusCategory category, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new AddBusCategoryCommand(category.CategoryName, category.BaseFare), cancellationToken);
                return CreatedAtAction(nameof(GetBusCategoryByIdAsync), new { categoryId = result.CategoryId }, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BusCategory>> GetBusCategoryByIdAsync(int categoryId, CancellationToken cancellationToken = default)
        {
            try
            {
                var categoryDetails = await _mediator.Send(new GetBusCategoryByIdQuery { CategoryId = categoryId }, cancellationToken);
                return Ok(categoryDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        // Adding the GetAllBusCategories API
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<BusCategory>>> GetAllBusCategoriesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var categories = await _mediator.Send(new GetAllBusCategoriesQuery(), cancellationToken);
                return Ok(categories);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut]
        [Route("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateBusCategoryAsync(int categoryId, UpdateBusCategoryCommand command, CancellationToken cancellationToken = default)
        {

            if (categoryId != command.CategoryId)
            {
                return BadRequest("ID mismatch between URL and request body.");
            }

            try
            {
                await _mediator.Send(command, cancellationToken);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete]
        [Route("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBusCategoryAsync(int categoryId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBusCategoryCommand { CategoryId = categoryId });

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