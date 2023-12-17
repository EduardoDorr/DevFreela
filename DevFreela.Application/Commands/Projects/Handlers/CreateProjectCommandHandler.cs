using MediatR;

namespace DevFreela.Application.Commands.Projects.Handlers;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    public Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}