using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.AddSkillToUser;

internal sealed class AddSkillToUserCommandHandler : IRequestHandler<AddSkillToUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly ISkillRepository _skillRepository;

    public AddSkillToUserCommandHandler(IUserRepository userRepository, ISkillRepository skillRepository)
    {
        _userRepository = userRepository;
        _skillRepository = skillRepository;
    }

    public async Task<Unit> Handle(AddSkillToUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            return Unit.Value;

        var skill = await _skillRepository.GetByIdAsync(request.SkillId);

        if (skill is null)
            return Unit.Value;

        user.AddSkill(new UserSkill(request.UserId, request.SkillId));

        _userRepository.Update(user);

        await _userRepository.SaveChangesAsync();

        return Unit.Value;
    }
}