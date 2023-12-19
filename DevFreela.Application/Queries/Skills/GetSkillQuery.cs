using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Skills;

public sealed class GetSkillQuery : IRequest<SkillViewModel?>
{
    public int Id { get; set; }

    public GetSkillQuery(int id)
    {
        Id = id;
    }
}