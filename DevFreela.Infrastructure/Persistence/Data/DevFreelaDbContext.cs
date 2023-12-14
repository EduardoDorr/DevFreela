using DevFreela.Domain.Entities;

namespace DevFreela.Infrastructure.Persistence.Data;

public class DevFreelaDbContext
{
    public List<Project> Projects { get; set; }
    public List<User> Users { get; set; }
    public List<Skill> Skills { get; set; }

    public DevFreelaDbContext()
    {
        Projects = new List<Project>()
        {
            new Project("Project 1", "Test project 1", 1, 1, 10000),
            new Project("Project 2", "Test project 2", 1, 1, 20000),
            new Project("Project 3", "Test project 3", 1, 1, 30000)
        };

        Users = new List<User>()
        {
            new User("Fulano de Tal", "fulano.tal@mail.com", new DateTime(1990, 1, 1)),
            new User("Beltrano da Silva", "beltrano.silva@mail.com", new DateTime(1975, 1, 1)),
            new User("Cicrano de Tales", "cicrano.tales@mail.com", new DateTime(1982, 1, 1))
        };

        Skills = new List<Skill>()
        {
            new Skill(".NET"),
            new Skill("Entity Framework"),
            new Skill("RabbitMq"),
            new Skill("SQL")
        };
    }
}