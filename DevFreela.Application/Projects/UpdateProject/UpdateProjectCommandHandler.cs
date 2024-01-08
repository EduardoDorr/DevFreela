using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.UpdateProject;

internal sealed class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(request.Id);

        if (project is null)
            return Unit.Value;

        project.Update(request.Title, request.Description, request.TotalCost);

        _unitOfWork.Projects.Update(project);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}