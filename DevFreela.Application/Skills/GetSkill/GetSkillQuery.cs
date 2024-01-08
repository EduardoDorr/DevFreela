using MediatR;
using DevFreela.Application.Skills.Shared;

namespace DevFreela.Application.Skills.GetSkill;

public sealed class GetSkillQuery : IRequest<SkillViewModel?>
{
    public int Id { get; set; }

    public GetSkillQuery(int id)
    {
        Id = id;
    }
}