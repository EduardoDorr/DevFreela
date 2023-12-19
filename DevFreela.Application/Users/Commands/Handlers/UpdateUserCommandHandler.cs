using MediatR;

using DevFreela.Infrastructure.Persistence.Data;
using DevFreela.Application.Users.Commands;

namespace DevFreela.Application.Users.Commands.Handlers;

internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public UpdateUserCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);

        if (user is null)
            return Unit.Value;

        user.Update(request.Name, request.Email, request.BirthDate);

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}