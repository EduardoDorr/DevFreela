using MediatR;

using DevFreela.Application.Users.Models;

namespace DevFreela.Application.Users.Commands;

public sealed class LoginUserCommand : IRequest<LoginUserViewModel?>
{
    public string Email { get; set; }
    public string Password { get; set; }
}