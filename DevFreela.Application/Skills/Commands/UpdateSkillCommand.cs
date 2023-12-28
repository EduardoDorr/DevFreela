using MediatR;

namespace DevFreela.Application.Skills.Commands;

public sealed class UpdateSkillCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Description { get; set; }
}