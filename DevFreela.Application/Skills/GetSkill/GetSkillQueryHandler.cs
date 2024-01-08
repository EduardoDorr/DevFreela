using MediatR;

using DevFreela.Domain.Repositories;
using DevFreela.Application.Skills.Shared;

namespace DevFreela.Application.Skills.GetSkill;

internal sealed class GetSkillQueryHandler : IRequestHandler<GetSkillQuery, SkillViewModel?>
{
    private readonly ISkillRepository _skillRepository;

    public GetSkillQueryHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<SkillViewModel?> Handle(GetSkillQuery request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);

        if (skill is null)
            return null;

        var skillViewModel =
            new SkillViewModel(skill.Id, skill.Description);

        return skillViewModel;
    }
}