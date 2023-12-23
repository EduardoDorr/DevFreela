using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.Commands.Handlers;

internal sealed class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
{
    private readonly IProjectRepository _projectRepository;

    public FinishProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        if (project is null)
            return Unit.Value;

        project.Finish();

        _projectRepository.Update(project);

        await _projectRepository.SaveChangesAsync();

        return Unit.Value;
    }
}