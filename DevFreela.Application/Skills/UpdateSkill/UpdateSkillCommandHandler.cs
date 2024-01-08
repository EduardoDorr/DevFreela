using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Skills.UpdateSkill;

internal sealed class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSkillCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _unitOfWork.Skills.GetByIdAsync(request.Id);

        if (skill is null)
            return Unit.Value;

        skill.Update(request.Description);

        _unitOfWork.Skills.Update(skill);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}