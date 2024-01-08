using MediatR;

namespace DevFreela.Application.Skills.CreateSkill;

public sealed class CreateSkillCommand : IRequest<int>
{
    public string Description { get; set; }
}