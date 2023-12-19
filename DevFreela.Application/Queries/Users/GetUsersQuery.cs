using MediatR;

using DevFreela.Application.Models.ViewModels;

namespace DevFreela.Application.Queries.Users;

public sealed record GetUsersQuery : IRequest<IEnumerable<UserViewModel>> { }