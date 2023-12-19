using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Projects;

public sealed record GetProjectQuery(int Id) : IRequest<ProjectDetailsViewModel?>;