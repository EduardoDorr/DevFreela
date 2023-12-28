using MediatR;
using DevFreela.Application.Skills.Models;

namespace DevFreela.Application.Skills.Queries;

public sealed class GetSkillQuery : IRequest<SkillViewModel?>
{
    public int Id { get; set; }

    public GetSkillQuery(int id)
    {
        Id = id;
    }
}