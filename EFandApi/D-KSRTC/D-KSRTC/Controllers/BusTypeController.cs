using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.BusTypes.AddBusType;
using D_KSRTC.Requests.Commands.BusTypes.DeleteBusType;
using D_KSRTC.Requests.Commands.BusTypes.UpdateBusType;
using D_KSRTC.Requests.Queries.BusTypes.GetAllBusTypes;
using D_KSRTC.Requests.Queries.BusTypes.GetBusTypeById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BusType>> AddBusTypeAsync(BusType busType, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(new AddBusTypeCommand
                {
                    TypeName = busType.TypeName,
                    PDF = busType.PDF
                }, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{typeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BusType>> GetBusTypeByIdAsync(int typeId, CancellationToken cancellationToken = default)
        {
            try
            {
                var busType = await _mediator.Send(new GetBusTypeByIdQuery { TypeId = typeId }, cancellationToken);

                if (busType == null)
                {
                    return NotFound();
                }

                return Ok(busType);
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
        public async Task<ActionResult<List<BusType>>> GetBusTypesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var busTypes = await _mediator.Send(new GetAllBusTypesQuery(), cancellationToken);

                if (busTypes == null)
                {
                    return NoContent();
                }

                return Ok(busTypes);
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
        public async Task<ActionResult> UpdateBusTypeAsync(int id, BusType busType, CancellationToken cancellationToken = default)
        {
            if (id != busType.TypeId)
            {
                return BadRequest("ID mismatch between URL and request body.");
            }

            try
            {
                var result = await _mediator.Send(new UpdateBusTypeCommand
                {
                    TypeId = busType.TypeId,
                    TypeName = busType.TypeName,
                    PDF = busType.PDF
                }, cancellationToken);

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
        public async Task<ActionResult> DeleteBusTypeAsync(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteBusTypeCommand { TypeId = id });

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

