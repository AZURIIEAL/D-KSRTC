﻿using D_KSRTC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using D_KSRTC.Requests.Commands.Project.CreateEntryPayload;

namespace D_KSRTC.DTO_s;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [Route("booking-data")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<bool>> BookTicketAsync([FromBody] PayloadDTO command, CancellationToken cancellationToken = default)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }
        try
        {
            var result = await _mediator.Send(new CreateEntryPayloadCommand { payload = command }, cancellationToken);
            return Ok(result);

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
             return StatusCode(StatusCodes.Status400BadRequest, "An error occurred while processing your request.");

        }
    }
}
