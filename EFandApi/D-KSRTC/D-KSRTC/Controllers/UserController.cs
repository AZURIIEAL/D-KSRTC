using D_KSRTC.Models;
using D_KSRTC.Requests.Commands.Users.AddUser;
using D_KSRTC.Requests.Queries.Location.GetAllLocation;
using D_KSRTC.Requests.Queries.Users.GetAllUsers;
using D_KSRTC.Requests.Queries.Users.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace D_KSRTC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> AddLocationAsync( AddUserCommand user, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _mediator.Send(user, cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet]
        [Route("{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetUserByIdAsync(int UserId, CancellationToken cancellationToken = default)
        {
            try
            {
                var userDetails = await _mediator.Send(new GetUsersByIdQuery { Id = UserId }, cancellationToken);

                if (userDetails == null)
                {
                    return NotFound();
                }

                return Ok(userDetails);
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
        public async Task<ActionResult<List<User>>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var userDetails = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
                if (userDetails == null)
                {
                    return NoContent(); // 204 No Content
                }
                return Ok(userDetails);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

    }
}
