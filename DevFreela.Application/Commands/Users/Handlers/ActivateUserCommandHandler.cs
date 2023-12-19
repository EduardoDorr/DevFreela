using MediatR;

using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Application.Commands.Users.Handlers;

internal sealed class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public ActivateUserCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);

        if (user is null)
            return Unit.Value;

        user.Activate();

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}