using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/v1/[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            if (user is null)
            return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel createUserModel)
        {
            var userId = _userService.Create(createUserModel);

            return CreatedAtAction(nameof(GetById), new { id = userId }, createUserModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateUserInputModel inputModel)
        {
            inputModel.Id = id;

            _userService.Update(inputModel);

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public IActionResult Activate(int id)
        {
            _userService.Activate(id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deactivate(int id)
        {
            _userService.Deactivate(id);

            return NoContent();
        }

        [HttpPut("add-skill/{userId}")]
        public IActionResult AddSkill(int userId, int skillId)
        {
            _userService.AddSkill(userId, skillId);

            return NoContent();
        }

        [HttpDelete("remove-skill/{userId}")]
        public IActionResult RemoveSkill(int userId, int skillId)
        {
            _userService.RemoveSkill(userId, skillId);

            return NoContent();
        }
    }
}
