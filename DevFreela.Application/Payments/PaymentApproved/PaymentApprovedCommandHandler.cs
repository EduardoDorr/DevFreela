using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Payments.PaymentApproved;

public class PaymentApprovedCommandHandler : IRequestHandler<PaymentApprovedCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public PaymentApprovedCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(PaymentApprovedCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(request.ProjectId);

        if (project is null)
            return false;

        project.Finish();

        _unitOfWork.Projects.Update(project);

        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}