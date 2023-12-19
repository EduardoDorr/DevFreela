using MediatR;

namespace DevFreela.Application.Commands.Projects;

public sealed class DeleteProjectCommand : IRequest<Unit>
{
    public DeleteProjectCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}