namespace DevFreela.Application.Payments.Models;

public record PaymentInfoInputModel(string CreditCardNumber, string Cvv, string ExpiresAt, string FullName, decimal Amount);