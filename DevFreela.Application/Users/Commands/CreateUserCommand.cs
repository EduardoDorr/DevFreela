using MediatR;

namespace DevFreela.Application.Users.Commands;

public sealed class CreateUserCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}