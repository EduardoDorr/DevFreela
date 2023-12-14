namespace DevFreela.Domain.Entities;

public class UserSkill : BaseEntity
{
    public int UserId { get; private set; }
    public Skill SkillId { get; private set; }
    
    public UserSkill(int userId, Skill skillId)
    {
        UserId = userId;
        SkillId = skillId;
    }
}