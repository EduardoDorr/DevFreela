using Microsoft.AspNetCore.Mvc;

using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.Models.InputModels;

namespace DevFreela.API.Controllers;

[Route("api/v1/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult GetAll(int skip = 0, int take = 50)
    {
        var projects = _projectService.GetAll(skip, take);

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _projectService.GetById(id);

        if (project is null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProjectInputModel createProject)
    {
        var projectId = _projectService.Create(createProject);

        return CreatedAtAction(nameof(GetById), new { id = projectId }, createProject);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateProjectInputModel updateProject)
    {
        updateProject.Id = id;

        _projectService.Update(updateProject);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _projectService.Delete(id);

        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public IActionResult CreateComment(int id, [FromBody] CreateCommentInputModel createComment)
    {
        createComment.ProjectId = id;

        _projectService.CreateComment(createComment);

        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        _projectService.Start(id);

        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id)
    {
        _projectService.Finish(id);

        return NoContent();
    }
}