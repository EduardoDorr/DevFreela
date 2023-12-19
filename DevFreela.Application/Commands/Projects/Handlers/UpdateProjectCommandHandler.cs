using MediatR;

using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Application.Commands.Projects.Handlers;

internal sealed class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public UpdateProjectCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _context.Projects.FirstOrDefault(x => x.Id == request.Id);

        if (project is null)
            return Unit.Value;

        project.Update(request.Title, request.Description, request.TotalCost);

        _context.Projects.Update(project);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}