using MediatR;

using DevFreela.Domain.Entities;
using DevFreela.Domain.Repositories;
using DevFreela.Domain.Services;

namespace DevFreela.Application.Users.CreateUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
    {
        _unitOfWork = unitOfWork;
        _authService = authService;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        var user = new User(request.Name, request.Email, request.BirthDate, passwordHash, request.Role);

        _unitOfWork.Users.Create(user);

        await _unitOfWork.SaveChangesAsync();

        return user.Id;
    }
}