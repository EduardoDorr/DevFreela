using MediatR;

namespace DevFreela.Application.Commands.Skills;

public sealed class CreateSkillCommand : IRequest<int>
{
    public string Description { get; set; }
}