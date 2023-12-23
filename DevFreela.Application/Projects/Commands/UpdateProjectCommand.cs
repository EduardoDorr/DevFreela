using MediatR;

namespace DevFreela.Application.Projects.Commands;

public sealed class UpdateProjectCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal TotalCost { get; set; }
}