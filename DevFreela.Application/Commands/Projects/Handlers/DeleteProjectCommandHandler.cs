using MediatR;

using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Application.Commands.Projects.Handlers;

internal sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public DeleteProjectCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _context.Projects.FirstOrDefault(x => x.Id == request.Id);

        if (project is null)
            return Unit.Value;

        project.Cancel();

        _context.Projects.Update(project);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}