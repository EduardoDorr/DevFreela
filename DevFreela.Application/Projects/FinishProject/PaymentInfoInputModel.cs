namespace DevFreela.Application.Projects.FinishProject;

public record PaymentInfoInputModel(string CreditCardNumber, string Cvv, string ExpiresAt, string FullName, decimal Amount);