using MediatR;
using DevFreela.Application.Projects.GetProjects;

namespace DevFreela.Application.Projects.GetProject;

public sealed record GetProjectQuery(int Id) : IRequest<ProjectDetailsViewModel?>;