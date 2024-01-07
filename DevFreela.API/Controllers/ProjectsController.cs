using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using MediatR;

using DevFreela.Application.Projects.Queries;
using DevFreela.Application.Projects.Commands;
using DevFreela.Domain.Dtos;
using DevFreela.Application.Payments.Models;

namespace DevFreela.API.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = "client, freelancer")]
    public async Task<IActionResult> GetAll(int skip = 0, int take = 50)
    {
        var projects = await _mediator.Send(new GetProjectsQuery());

        return Ok(projects);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "client, freelancer")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _mediator.Send(new GetProjectQuery(id));

        if (project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
    {
        var projectId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = projectId }, command);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProjectCommand(id));

        return NoContent();
    }

    [HttpPost("{id}/comments")]
    [Authorize(Roles = "client, freelancer")]
    public async Task<IActionResult> CreateComment(int id, [FromBody] CreateCommentCommand command)
    {
        command.ProjectId = id;

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{id}/start")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Start(int id)
    {
        await _mediator.Send(new StartProjectCommand(id));

        return NoContent();
    }

    [HttpPut("{id}/finish")]
    [Authorize(Roles = "client")]
    public async Task<IActionResult> Finish(int id, [FromBody] PaymentInfoInputModel paymentInfoInputModel)
    {
        var command =
            new FinishProjectCommand(id,
                                     paymentInfoInputModel.CreditCardNumber,
                                     paymentInfoInputModel.Cvv,
                                     paymentInfoInputModel.ExpiresAt,
                                     paymentInfoInputModel.FullName,
                                     paymentInfoInputModel.Amount);

        var result = await _mediator.Send(command);

        if (!result)
            return BadRequest();

        return Accepted();
    }
}