using MediatR;

namespace DevFreela.Application.Skills.Commands;

public sealed class CreateSkillCommand : IRequest<int>
{
    public string Description { get; set; }
}