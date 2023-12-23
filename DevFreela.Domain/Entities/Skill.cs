namespace DevFreela.Domain.Entities;

public class Skill : BaseEntity
{
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public virtual ICollection<UserSkill> UserSkills { get; private set; }

    protected Skill() { }

    public Skill(string description)
    {
        Description = description;

        CreatedAt = DateTime.Now;
    }

    public void Update(string description)
    {
        Description = description;
    }
}