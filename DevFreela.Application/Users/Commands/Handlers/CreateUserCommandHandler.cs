using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.Commands.Handlers;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email, request.BirthDate);

        _userRepository.Create(user);

        await _userRepository.SaveChangesAsync();

        return user.Id;
    }
}