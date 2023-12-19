using MediatR;

namespace DevFreela.Application.Commands.Projects;

public sealed class CreateCommentCommand : IRequest<Unit>
{
    public string Content { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
}