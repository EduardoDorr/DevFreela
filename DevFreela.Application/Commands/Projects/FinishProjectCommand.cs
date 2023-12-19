using MediatR;

namespace DevFreela.Application.Commands.Projects;

public sealed class FinishProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public FinishProjectCommand(int id)
    {
        Id = id;
    }
}