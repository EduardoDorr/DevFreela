namespace DevFreela.Domain.Dtos;

public record PaymentInfoDto(int ProjectId, string CreditCardNumber, string Cvv, string ExpiresAt, string FullName, decimal Amount);