using MediatR;

namespace DevFreela.Application.Skills.UpdateSkill;

public sealed class UpdateSkillCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Description { get; set; }
}