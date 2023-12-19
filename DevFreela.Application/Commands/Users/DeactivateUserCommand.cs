using MediatR;

namespace DevFreela.Application.Commands.Users;

public sealed class DeactivateUserCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeactivateUserCommand(int id)
    {
        Id = id;
    }
}