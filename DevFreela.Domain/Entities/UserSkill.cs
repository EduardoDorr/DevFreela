namespace DevFreela.Domain.Entities;

public class UserSkill : BaseEntity
{
    public int UserId { get; private set; }
    public int SkillId { get; private set; }

    public virtual User User { get; private set; }
    public virtual Skill Skill { get; private set; }
    
    protected UserSkill() { }

    public UserSkill(int userId, int skillId)
    {
        UserId = userId;
        SkillId = skillId;
    }
}