using MediatR;
using DevFreela.Application.Projects.Models;

namespace DevFreela.Application.Projects.Queries;

public sealed record GetProjectsQuery() : IRequest<IEnumerable<ProjectViewModel>>;