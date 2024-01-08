using MediatR;

namespace DevFreela.Application.Projects.StartProject;

public sealed class StartProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public StartProjectCommand(int id)
    {
        Id = id;
    }
}