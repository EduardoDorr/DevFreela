namespace DevFreela.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Active { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }

    public virtual ICollection<UserSkill> UserSkills { get; private set; }
    public virtual ICollection<ProjectComment> Comments { get; private set; }
    public virtual ICollection<Project> OwnedProjects { get; private set; }
    public virtual ICollection<Project> FreelanceProjects { get; private set; }

    protected User() { }

    public User(string name, string email, DateTime birthDate, string password, string role)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;

        CreatedAt = DateTime.Now;
        Active = true;
        UserSkills = new List<UserSkill>();
        OwnedProjects = new List<Project>();
        FreelanceProjects = new List<Project>();
        Password = password;
        Role = role;
    }

    public void Update(string name, string email, DateTime birthDate)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
    }

    public void Activate() => Active = true;

    public void Deactivate() => Active = false;

    public void AddSkill(UserSkill skill) => UserSkills.Add(skill);

    public void RemoveSkill(UserSkill skill) => UserSkills.Remove(skill);
}