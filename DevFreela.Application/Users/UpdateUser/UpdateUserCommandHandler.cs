using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

        if (user is null)
            return Unit.Value;

        user.Update(request.Name, request.Email, request.BirthDate);

        _unitOfWork.Users.Update(user);

        await _unitOfWork.CompleteAsync();

        return Unit.Value;
    }
}