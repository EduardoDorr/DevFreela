using MediatR;

namespace DevFreela.Application.Users.Commands;

public sealed class ActivateUserCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public ActivateUserCommand(int id)
    {
        Id = id;
    }
}