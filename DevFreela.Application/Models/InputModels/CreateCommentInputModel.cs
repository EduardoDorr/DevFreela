namespace DevFreela.Application.Models.InputModels;

public class CreateCommentInputModel
{
    public string Content { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
}