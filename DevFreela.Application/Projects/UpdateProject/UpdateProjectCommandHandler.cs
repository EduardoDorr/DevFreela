using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.UpdateProject;

internal sealed class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public UpdateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        if (project is null)
            return Unit.Value;

        project.Update(request.Title, request.Description, request.TotalCost);

        _projectRepository.Update(project);

        await _projectRepository.SaveChangesAsync();

        return Unit.Value;
    }
}