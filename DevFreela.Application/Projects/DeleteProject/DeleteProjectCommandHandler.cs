using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.DeleteProject;

internal sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(request.Id);

        if (project is null)
            return Unit.Value;

        project.Cancel();

        _unitOfWork.Projects.Update(project);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}