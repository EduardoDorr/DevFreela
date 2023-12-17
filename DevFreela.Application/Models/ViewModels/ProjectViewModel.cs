namespace DevFreela.Application.Models.ViewModels;

public class ProjectViewModel
{
    public string Title { get; }
    public string Description { get; }
    public DateTime CreatedAt { get; }

    public ProjectViewModel(string title, string description, DateTime createdAt)
    {
        Title = title;
        Description = description;
        CreatedAt = createdAt;
    }
}