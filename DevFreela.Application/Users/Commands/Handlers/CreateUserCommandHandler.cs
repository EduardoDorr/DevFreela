using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Infrastructure.Persistence.Data;
using DevFreela.Application.Users.Commands;

namespace DevFreela.Application.Users.Commands.Handlers;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly DevFreelaDbContext _context;

    public CreateUserCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email, request.BirthDate);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user.Id;
    }
}