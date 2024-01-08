using MediatR;

namespace DevFreela.Application.Users.ActivateUser;

public sealed class ActivateUserCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public ActivateUserCommand(int id)
    {
        Id = id;
    }
}