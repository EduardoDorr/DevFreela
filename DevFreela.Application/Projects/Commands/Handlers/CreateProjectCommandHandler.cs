using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.Commands.Handlers;

public sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Title, request.Description, request.ClientId, request.FreelancerId, request.TotalCost);

        _projectRepository.Create(project);

        await _projectRepository.SaveChangesAsync();

        return project.Id;
    }
}