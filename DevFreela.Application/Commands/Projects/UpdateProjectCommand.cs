using MediatR;

namespace DevFreela.Application.Commands.Projects;

public sealed class UpdateProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal TotalCost { get; set; }
}