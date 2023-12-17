namespace DevFreela.Application.Models.ViewModels;

public class ProjectDetailsViewModel
{
    public int Id { get; }
    public string Title { get; }
    public string Description { get; }
    public DateTime? StartedAt { get; }
    public DateTime? FinishedAt { get; }
    public decimal TotalCost { get; }
    public DateTime CreatedAt { get; }
    public string ClientName { get; }
    public string FreelancerName { get; }

    public ProjectDetailsViewModel(int id, string title, string description,
                                   DateTime? startedAt, DateTime? finishedAt,
                                   decimal totalCost, DateTime createdAt,
                                   string clientName, string freelancerName)
    {
        Id = id;
        Title = title;
        Description = description;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
        TotalCost = totalCost;
        CreatedAt = createdAt;
        ClientName = clientName;
        FreelancerName = freelancerName;
    }
}