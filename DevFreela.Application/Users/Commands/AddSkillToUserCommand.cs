using MediatR;

namespace DevFreela.Application.Users.Commands;

public sealed class AddSkillToUserCommand : IRequest<Unit>
{
    public int UserId { get; set; }
    public int SkillId { get; set; }

    public AddSkillToUserCommand(int userId, int skillId)
    {
        UserId = userId;
        SkillId = skillId;
    }
}