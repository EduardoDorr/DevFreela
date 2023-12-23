using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.Commands.Handlers;

internal sealed class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public ActivateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            return Unit.Value;

        user.Activate();

        _userRepository.Update(user);

        await _userRepository.SaveChangesAsync();

        return Unit.Value;
    }
}