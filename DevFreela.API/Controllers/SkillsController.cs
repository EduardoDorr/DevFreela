using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using DevFreela.Application.Skills.Queries;
using DevFreela.Application.Skills.Commands;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkillsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _mediator.Send(new GetSkillsQuery());

        return Ok(users);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _mediator.Send(new GetSkillQuery(id));

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSkillCommand command)
    {
        var skillId = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = skillId }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSkillCommand command)
    {
        command.Id = id;

        await _mediator.Send(command);

        return NoContent();
    }
}