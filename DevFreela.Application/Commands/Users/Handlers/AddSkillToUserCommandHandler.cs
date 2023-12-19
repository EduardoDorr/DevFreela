using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Application.Commands.Users.Handlers;

internal sealed class AddSkillToUserCommandHandler : IRequestHandler<AddSkillToUserCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public AddSkillToUserCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddSkillToUserCommand request, CancellationToken cancellationToken)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == request.UserId);

        if (user is null)
            return Unit.Value;

        var skill = _context.Skills.FirstOrDefault(x => x.Id == request.SkillId);

        if (skill is null)
            return Unit.Value;

        user.AddSkill(new UserSkill(request.UserId, request.SkillId));

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}