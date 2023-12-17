using Microsoft.EntityFrameworkCore;

using DevFreela.Domain.Entities;
using DevFreela.Application.Models.ViewModels;
using DevFreela.Application.Models.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Application.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly DevFreelaDbContext _context;

    public ProjectService(DevFreelaDbContext context)
    {
        _context = context;
    }

    public List<ProjectViewModel> GetAll(int skip = 0, int take = 50)
    {
        var projects = _context.Projects.Skip(skip).Take(take).ToList();

        var viewModels = projects.Select(p => new ProjectViewModel(p.Title, p.Description, p.CreatedAt))
                                 .ToList();

        return viewModels;
    }

    public ProjectDetailsViewModel? GetById(int id)
    {
        var project = _context.Projects.Include(p => p.Client)
                                       .Include(p => p.Freelancer)
                                       .FirstOrDefault(p => p.Id == id);

        if (project is null)
            return null;

        var viewModel =
            new ProjectDetailsViewModel(project.Id,
                                        project.Title,
                                        project.Description,
                                        project.StartedAt,
                                        project.FinishedAt,
                                        project.TotalCost,
                                        project.CreatedAt,
                                        project.Client.Name,
                                        project.Freelancer.Name);

        return viewModel;
    }

    public int Create(CreateProjectInputModel inputModel)
    {
        var project = new Project(inputModel.Title, inputModel.Description, inputModel.ClientId, inputModel.FreelancerId, inputModel.TotalCost);

        _context.Projects.Add(project);
        _context.SaveChanges();

        return project.Id;
    }

    public void Update(UpdateProjectInputModel inputModel)
    {
        var projectToUpdate = _context.Projects.FirstOrDefault(x => x.Id == inputModel.Id);

        if (projectToUpdate is null)
            return;

        projectToUpdate.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);

        _context.Projects.Update(projectToUpdate);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var projectToRemove = _context.Projects.FirstOrDefault(x => x.Id == id);

        if (projectToRemove is null)
            return;

        projectToRemove.Cancel();

        _context.Projects.Update(projectToRemove);
        _context.SaveChanges();
    }

    public void CreateComment(CreateCommentInputModel inputModel)
    {
        var comment = new ProjectComment(inputModel.Content, inputModel.ProjectId, inputModel.UserId);

        _context.ProjectComments.Add(comment);
        _context.SaveChanges();
    }

    public void Start(int id)
    {
        var projectToStart = _context.Projects.FirstOrDefault(x => x.Id == id);

        if (projectToStart is null)
            return;

        projectToStart.Start();

        _context.Projects.Update(projectToStart);
        _context.SaveChanges();
    }

    public void Finish(int id)
    {
        var projectToFinish = _context.Projects.FirstOrDefault(x => x.Id == id);

        if (projectToFinish is null)
            return;

        projectToFinish.Start();

        _context.Projects.Update(projectToFinish);
        _context.SaveChanges();
    }
}