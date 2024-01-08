using MediatR;
using DevFreela.Application.Users.Shared;

namespace DevFreela.Application.Users.GetUsers;

public sealed record GetUsersQuery : IRequest<IEnumerable<UserViewModel>> { }