using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.DeactivateUser;

internal sealed class DeactivateUserCommandHandler : IRequestHandler<DeactivateUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeactivateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

        if (user is null)
            return Unit.Value;

        user.Deactivate();

        _unitOfWork.Users.Update(user);

        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}