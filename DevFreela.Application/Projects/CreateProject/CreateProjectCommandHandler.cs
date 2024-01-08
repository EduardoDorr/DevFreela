using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.CreateProject;

public sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Title, request.Description, request.ClientId, request.FreelancerId, request.TotalCost);

        _unitOfWork.Projects.Create(project);

        await _unitOfWork.SaveChangesAsync();

        return project.Id;
    }
}