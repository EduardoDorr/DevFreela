using MediatR;

namespace DevFreela.Application.Payments.PaymentApproved;

public sealed record PaymentApprovedCommand(int ProjectId) : IRequest<bool>;