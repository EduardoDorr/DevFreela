using MediatR;
using DevFreela.Application.Projects.Models;

namespace DevFreela.Application.Projects.Queries;

public sealed record GetProjectQuery(int Id) : IRequest<ProjectDetailsViewModel?>;