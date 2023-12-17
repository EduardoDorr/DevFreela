using MediatR;

namespace DevFreela.Application.Commands.Projects;

public class CreateProjectCommand : IRequest<int>
{
    public CreateProjectCommand()
    {
    }
}