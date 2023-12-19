using MediatR;

using DevFreela.Infrastructure.Persistence.Data;
using DevFreela.Application.Skills.Commands;

namespace DevFreela.Application.Skills.Commands.Handlers;

internal sealed class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, Unit>
{
    private readonly DevFreelaDbContext _context;

    public UpdateSkillCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = _context.Skills.FirstOrDefault(s => s.Id == request.Id);

        if (skill is null)
            return Unit.Value;

        skill.Update(request.Description);

        _context.Skills.Update(skill);
        await _context.SaveChangesAsync();

        return Unit.Value;
    }
}