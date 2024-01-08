using MediatR;

using DevFreela.Domain.Repositories;
using DevFreela.Application.Skills.Shared;

namespace DevFreela.Application.Skills.GetSkills;

internal sealed class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, IEnumerable<SkillViewModel>>
{
    private readonly ISkillRepository _skillRepository;

    public GetSkillsQueryHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<IEnumerable<SkillViewModel>> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills = await _skillRepository.GetAllAsync();

        var skillsViewModel =
            skills.Select(p => new SkillViewModel(p.Id, p.Description))
                  .ToList();

        return skillsViewModel;
    }
}