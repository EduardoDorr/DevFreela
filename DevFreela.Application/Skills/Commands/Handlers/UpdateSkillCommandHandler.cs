using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Skills.Commands.Handlers;

internal sealed class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, Unit>
{
    private readonly ISkillRepository _skillRepository;

    public UpdateSkillCommandHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<Unit> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);

        if (skill is null)
            return Unit.Value;

        skill.Update(request.Description);

        _skillRepository.Update(skill);

        await _skillRepository.SaveChangesAsync();

        return Unit.Value;
    }
}