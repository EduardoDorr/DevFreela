using MediatR;
using DevFreela.Application.Users.Models;

namespace DevFreela.Application.Users.Queries;

public sealed record GetUsersQuery : IRequest<IEnumerable<UserViewModel>> { }