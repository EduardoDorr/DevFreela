using MediatR;

namespace DevFreela.Application.Users.LoginUser;

public sealed class LoginUserCommand : IRequest<LoginUserViewModel?>
{
    public string Email { get; set; }
    public string Password { get; set; }
}