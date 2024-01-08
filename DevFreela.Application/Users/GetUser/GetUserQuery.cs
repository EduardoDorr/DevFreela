using MediatR;
using DevFreela.Application.Users.Shared;

namespace DevFreela.Application.Users.GetUser;

public sealed record GetUserQuery(int Id) : IRequest<UserViewModel?>;