using DevFreela.Domain.Enums;

namespace DevFreela.Domain.Entities;

public class Project : BaseEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int ClientId { get; private set; }
    public int FreelancerId { get; private set; }
    public decimal TotalCost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? FinishedAt { get; private set; }
    public ProjectStatus Status { get; private set; }
    public List<ProjectComment> Comments { get; private set; }

    public virtual User Client { get; private set; }
    public virtual User Freelancer { get; private set; }

    protected Project() { }

    public Project(string title, string description, int clientId, int freelancerId, decimal totalCost)
    {
        Title = title;
        Description = description;
        ClientId = clientId;
        FreelancerId = freelancerId;
        TotalCost = totalCost;

        CreatedAt = DateTime.Now;
        Status = ProjectStatus.Created;
        Comments = new List<ProjectComment>();
    }

    public void Start()
    {
        if (Status == ProjectStatus.Created)
        {
            StartedAt = DateTime.Now;
            Status = ProjectStatus.InProgress;
        }
    }

    public void Finish()
    {
        if (Status == ProjectStatus.InProgress)
        {
            FinishedAt = DateTime.Now;
            Status = ProjectStatus.Finished;
        }
    }

    public void Cancel()
    {
        if (Status == ProjectStatus.Created || Status == ProjectStatus.InProgress)
        {
            FinishedAt = DateTime.Now;
            Status = ProjectStatus.Cancelled;
        }
    }

    public void Update(string title, string description, decimal totalCost)
    {
        Title = title;
        Description = description;
        TotalCost = totalCost;
    }
}