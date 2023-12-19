using MediatR;

using DevFreela.Domain.Repositories;
using DevFreela.Application.Skills.Models;
using DevFreela.Application.Skills.Queries;

namespace DevFreela.Application.Skills.Queries.Handlers;

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