using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.ActivateUser;

internal sealed class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public ActivateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

        if (user is null)
            return Unit.Value;

        user.Activate();

        _unitOfWork.Users.Update(user);

        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}