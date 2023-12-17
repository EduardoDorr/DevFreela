using Microsoft.AspNetCore.Mvc;

using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Services.Interfaces;

namespace DevFreela.API.Controllers;

[Route("api/v1/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _skillService.GetAll();

        return Ok(users);
    }

    [HttpGet("id")]
    public IActionResult GetById(int id)
    {
        var user = _skillService.GetById(id);

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateSkillInputModel inputModel)
    {
        var skillId = _skillService.Create(inputModel);

        return CreatedAtAction(nameof(GetById), new { id = skillId }, inputModel);
    }

    // api/projects/2
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateSkillInputModel inputModel)
    {
        inputModel.Id = id;

        _skillService.Update(inputModel);

        return NoContent();
    }
}