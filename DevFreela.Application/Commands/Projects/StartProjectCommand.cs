using MediatR;

namespace DevFreela.Application.Commands.Projects;

public sealed class StartProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public StartProjectCommand(int id)
    {
        Id = id;
    }
}