using MediatR;

using DevFreela.Domain.Repositories;
using DevFreela.Application.Projects.GetProject;
using DevFreela.Domain.Models;

namespace DevFreela.Application.Projects.GetProjects;

public sealed class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, PaginationResult<ProjectViewModel>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectsQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<PaginationResult<ProjectViewModel>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
    {
        var paginationProjects = await _projectRepository.GetAllAsync(request.Query, request.Page, request.PageSize);

        var projectsViewModel =
            paginationProjects
                .Data
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
                .ToList();

        var paginationPrjectsViewModel =
            new PaginationResult<ProjectViewModel>
            (
                paginationProjects.Page,
                paginationProjects.PageSize,
                paginationProjects.TotalCount,
                paginationProjects.TotalPages,
                projectsViewModel
            );

        return paginationPrjectsViewModel;
    }
}