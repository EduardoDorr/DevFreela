using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Skills.CreateSkill;

internal sealed class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
{
    private readonly ISkillRepository _skillRepository;

    public CreateSkillCommandHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new Skill(request.Description);

        _skillRepository.Create(skill);

        await _skillRepository.SaveChangesAsync();

        return skill.Id;
    }
}