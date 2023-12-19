using MediatR;

using DevFreela.Domain.Repositories;
using DevFreela.Application.Projects.Models;
using DevFreela.Application.Projects.Queries;

namespace DevFreela.Application.Projects.Queries.Handlers;

internal sealed class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDetailsViewModel?>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ProjectDetailsViewModel?> Handle(GetProjectQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        if (project is null)
            return null;

        var projectDetailViewModel =
            new ProjectDetailsViewModel(project.Id, project.Title, project.Description, project.StartedAt, project.FinishedAt,
                                        project.TotalCost, project.CreatedAt, project.ClientName, project.FreelancerName);

        return projectDetailViewModel;
    }
}