using MediatR;

namespace DevFreela.Application.Payments.Commands;

public sealed record PaymentApprovedCommand(int ProjectId) : IRequest<bool>;