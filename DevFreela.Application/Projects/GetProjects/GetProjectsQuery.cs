using MediatR;

using DevFreela.Domain.Models;
using DevFreela.Application.Projects.GetProject;

namespace DevFreela.Application.Projects.GetProjects;

public sealed record GetProjectsQuery(string Query = "", int Page = 1, int PageSize = 2) : IRequest<PaginationResult<ProjectViewModel>>;