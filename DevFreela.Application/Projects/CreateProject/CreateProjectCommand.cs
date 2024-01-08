using MediatR;

namespace DevFreela.Application.Projects.CreateProject;

public sealed record CreateProjectCommand(string Title, string Description, int ClientId, int FreelancerId, decimal TotalCost) : IRequest<int>;