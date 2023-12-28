using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.Commands.Handlers;

internal sealed class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public StartProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        if (project is null)
            return Unit.Value;

        project.Start();

        _projectRepository.Update(project);

        await _projectRepository.SaveChangesAsync();

        return Unit.Value;
    }
}