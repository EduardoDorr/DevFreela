using MediatR;

using DevFreela.Infrastructure.Persistence.Data;
using DevFreela.Application.Projects.Commands;

namespace DevFreela.Application.Projects.Commands.Handlers;

internal sealed class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public FinishProjectCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
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