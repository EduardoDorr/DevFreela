namespace DevFreela.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; }

    public List<UserSkill> UserSkills { get; private set; }
    public List<Project> OwnedProjects { get; private set; }
    public List<Project> FreelanceProjects { get; private set; }

    public User(string name, string email, DateTime birthDate)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;

        CreatedAt = DateTime.Now;
        Active = true;
        UserSkills = new List<UserSkill>();
        OwnedProjects = new List<Project>();
        FreelanceProjects = new List<Project>();
    }
}
