using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Infrastructure.Persistence.Data;

namespace DevFreela.Application.Commands.Skills.Handlers;

internal sealed class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
{
    private readonly DevFreelaDbContext _context;

    public CreateSkillCommandHandler(DevFreelaDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new Skill(request.Description);

        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();

        return skill.Id;
    }
}