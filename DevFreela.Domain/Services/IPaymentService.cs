using DevFreela.Domain.Dtos;

namespace DevFreela.Domain.Services;

public interface IPaymentService
{
    void ProcessPayment(PaymentInfoDto paymentInfoDto);
    Task<bool> ProcessPaymentByApi(PaymentInfoDto paymentInfoDto);
}