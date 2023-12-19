using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Infrastructure.Persistence.Data;
using DevFreela.Application.Projects.Commands;

namespace DevFreela.Application.Projects.Commands.Handlers;

public sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly DevFreelaDbContext _context;

    public CreateProjectCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(request.Title, request.Description, request.ClientId, request.FreelancerId, request.TotalCost);

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        return project.Id;
    }
}