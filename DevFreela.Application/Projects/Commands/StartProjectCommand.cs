using MediatR;

namespace DevFreela.Application.Projects.Commands;

public sealed class StartProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public StartProjectCommand(int id)
    {
        Id = id;
    }
}