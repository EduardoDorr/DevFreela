using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using DevFreela.Domain.Services;

namespace DevFreela.Application.Users.Commands.Handlers;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        var user = new User(request.Name, request.Email, request.BirthDate, passwordHash, request.Role);

        _userRepository.Create(user);

        await _userRepository.SaveChangesAsync();

        return user.Id;
    }
}