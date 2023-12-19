using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Projects;

public sealed record GetProjectsQuery() : IRequest<IEnumerable<ProjectViewModel>>;