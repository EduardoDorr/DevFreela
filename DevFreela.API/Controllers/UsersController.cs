using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using MediatR;

using DevFreela.Application.Users.Queries;
using DevFreela.Application.Users.Commands;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetUsersQuery());

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));

            if (user is null)
            return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = userId }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> Activate(int id)
        {
            await _mediator.Send(new ActivateUserCommand(id));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _mediator.Send(new DeactivateUserCommand(id));

            return NoContent();
        }

        [HttpPut("add-skill/{userId}")]
        public async Task<IActionResult> AddSkill(int userId, int skillId)
        {
            await _mediator.Send(new AddSkillToUserCommand(userId, skillId));

            return NoContent();
        }

        [HttpDelete("remove-skill/{userId}")]
        public async Task<IActionResult> RemoveSkill(int userId, int skillId)
        {
            await _mediator.Send(new RemoveSkillFromUserCommand(userId, skillId));

            return NoContent();
        }
    }
}
