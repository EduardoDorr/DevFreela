using MediatR;

using DevFreela.Domain.Dtos;
using DevFreela.Domain.Services;
using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Projects.FinishProject;

internal sealed class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IPaymentService _paymentService;

    public FinishProjectCommandHandler(IProjectRepository projectRepository, IPaymentService paymentService)
    {
        _projectRepository = projectRepository;
        _paymentService = paymentService;
    }

    public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        if (project is null)
            return false;

        var paymentInfoDto =
            new PaymentInfoDto(request.Id, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, request.Amount);

        _paymentService.ProcessPayment(paymentInfoDto);

        project.SetPaymentPending();

        _projectRepository.Update(project);

        return await _projectRepository.SaveChangesAsync();
    }
}