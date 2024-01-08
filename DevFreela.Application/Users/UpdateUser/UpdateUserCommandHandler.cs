using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            return Unit.Value;

        user.Update(request.Name, request.Email, request.BirthDate);

        _userRepository.Update(user);

        await _userRepository.SaveChangesAsync();

        return Unit.Value;
    }
}