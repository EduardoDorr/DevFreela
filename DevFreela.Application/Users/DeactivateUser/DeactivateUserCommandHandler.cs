using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.DeactivateUser;

internal sealed class DeactivateUserCommandHandler : IRequestHandler<DeactivateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeactivateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            return Unit.Value;

        user.Deactivate();

        _userRepository.Update(user);

        await _userRepository.SaveChangesAsync();

        return Unit.Value;
    }
}