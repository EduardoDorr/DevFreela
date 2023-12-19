using MediatR;

namespace DevFreela.Application.Commands.Users;

public sealed class CreateUserCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}