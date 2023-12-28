using MediatR;

namespace DevFreela.Application.Projects.Commands;

public sealed class DeleteProjectCommand : IRequest<Unit>
{
    public DeleteProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}