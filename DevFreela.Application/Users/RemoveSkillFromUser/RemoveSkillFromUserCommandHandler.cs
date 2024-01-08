using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.RemoveSkillFromUser;

internal sealed class RemoveSkillFromUserCommandHandler : IRequestHandler<RemoveSkillFromUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveSkillFromUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveSkillFromUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);

        if (user is null)
            return Unit.Value;

        var skill = user.UserSkills.SingleOrDefault(s => s.SkillId == request.SkillId);

        if (skill is null)
            return Unit.Value;

        user.RemoveSkill(skill);

        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}