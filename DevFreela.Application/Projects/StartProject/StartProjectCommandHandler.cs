using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.StartProject;

internal sealed class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public StartProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(request.Id);

        if (project is null)
            return Unit.Value;

        project.Start();

        _unitOfWork.Projects.Update(project);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}