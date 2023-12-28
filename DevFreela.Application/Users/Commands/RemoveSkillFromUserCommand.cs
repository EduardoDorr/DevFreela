using MediatR;

namespace DevFreela.Application.Users.Commands;

public sealed class RemoveSkillFromUserCommand : IRequest<Unit>
{
    public int UserId { get; set; }
    public int SkillId { get; set; }

    public RemoveSkillFromUserCommand(int userId, int skillId)
    {
        UserId = userId;
        SkillId = skillId;
    }
}