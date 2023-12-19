using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using DevFreela.Application.Queries.Projects;
using DevFreela.Application.Commands.Projects;

namespace DevFreela.API.Controllers;

[Route("api/v1/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int skip = 0, int take = 50)
    {
        var projects = await _mediator.Send(new GetProjectsQuery());

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var project = await _mediator.Send(new GetProjectQuery(id));

        if (project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
    {
        var projectId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = projectId }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProjectCommand(id));

        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public async Task<IActionResult> CreateComment(int id, [FromBody] CreateCommentCommand command)
    {
        command.ProjectId = id;

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(int id)
    {
        await _mediator.Send(new StartProjectCommand(id));

        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public async Task<IActionResult> Finish(int id)
    {
        await _mediator.Send(new FinishProjectCommand(id));

        return NoContent();
    }
}