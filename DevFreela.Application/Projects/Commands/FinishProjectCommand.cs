using MediatR;

namespace DevFreela.Application.Projects.Commands;

public sealed class FinishProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public FinishProjectCommand(int id)
    {
        Id = id;
    }
}