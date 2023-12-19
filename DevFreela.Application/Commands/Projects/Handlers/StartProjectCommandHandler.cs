using MediatR;

using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Application.Commands.Projects.Handlers;

internal sealed class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public StartProjectCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
    {
        var project = _context.Projects.FirstOrDefault(x => x.Id == request.Id);

        if (project is null)
            return Unit.Value;

        project.Start();

        _context.Projects.Update(project);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}
