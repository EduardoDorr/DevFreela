using MediatR;

namespace DevFreela.Application.Commands.Skills;

public sealed class UpdateSkillCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Description { get; set; }
}