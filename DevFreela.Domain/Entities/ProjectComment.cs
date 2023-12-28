namespace DevFreela.Domain.Entities;

public class ProjectComment : BaseEntity
{
    public string Content { get; private set; }
    public int ProjectId { get; private set; }
    public int UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public virtual User User { get; private set; }
    public virtual Project Project { get; private set; }

    protected ProjectComment() { }

    public ProjectComment(string content, int projectId, int userId)
    {
        Content = content;
        ProjectId = projectId;
        UserId = userId;

        CreatedAt = DateTime.Now;
    }
}