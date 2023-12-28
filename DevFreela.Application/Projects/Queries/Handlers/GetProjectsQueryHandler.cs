using MediatR;

using DevFreela.Domain.Repositories;
using DevFreela.Application.Projects.Models;

namespace DevFreela.Application.Projects.Queries.Handlers;

public sealed class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, IEnumerable<ProjectViewModel>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectsQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<ProjectViewModel>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetAllAsync();

        var projectsViewModel =
            projects.Select(p => new ProjectViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
                    .ToList();

        return projectsViewModel;
    }
}