using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.Commands.Handlers;

internal sealed class RemoveSkillFromUserCommandHandler : IRequestHandler<RemoveSkillFromUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public RemoveSkillFromUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(RemoveSkillFromUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            return Unit.Value;

        var skill = user.UserSkills.SingleOrDefault(s => s.SkillId == request.SkillId);

        if (skill is null)
            return Unit.Value;

        user.RemoveSkill(skill);

        _userRepository.Update(user);

        await _userRepository.SaveChangesAsync();

        return Unit.Value;
    }
}
