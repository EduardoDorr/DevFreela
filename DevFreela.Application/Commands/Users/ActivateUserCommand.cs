using MediatR;

namespace DevFreela.Application.Commands.Users;

public sealed class ActivateUserCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public ActivateUserCommand(int id)
    {
        Id = id;
    }
}