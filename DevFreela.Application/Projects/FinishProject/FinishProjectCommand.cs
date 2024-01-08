using MediatR;

namespace DevFreela.Application.Projects.FinishProject;

public sealed class FinishProjectCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string CreditCardNumber { get; set; }
    public string Cvv { get; set; }
    public string ExpiresAt { get; set; }
    public string FullName { get; set; }
    public decimal Amount { get; set; }

    public FinishProjectCommand(int id, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
    {
        Id = id;
        CreditCardNumber = creditCardNumber;
        Cvv = cvv;
        ExpiresAt = expiresAt;
        FullName = fullName;
        Amount = amount;
    }
}