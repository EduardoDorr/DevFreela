using MediatR;

using DevFreela.Domain.Repositories;

namespace DevFreela.Application.Payments.Commands.Handlers;

public class PaymentApprovedCommandHandler : IRequestHandler<PaymentApprovedCommand, bool>
{
    private readonly IProjectRepository _projectRepository;

    public PaymentApprovedCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<bool> Handle(PaymentApprovedCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.ProjectId);

        if (project is null)
            return false;

        project.Finish();

        _projectRepository.Update(project);

        return await _projectRepository.SaveChangesAsync();
    }
}