using MediatR;
using DevFreela.Application.Users.Models;

namespace DevFreela.Application.Users.Queries;

public sealed record GetUserQuery(int Id) : IRequest<UserViewModel?>;