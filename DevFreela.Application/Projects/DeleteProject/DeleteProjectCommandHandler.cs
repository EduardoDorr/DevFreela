using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.DeleteProject;

internal sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public DeleteProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        if (project is null)
            return Unit.Value;

        project.Cancel();

        _projectRepository.Update(project);

        await _projectRepository.SaveChangesAsync();

        return Unit.Value;
    }
}