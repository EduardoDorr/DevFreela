using System.Text;
using System.Text.Json;

using Microsoft.Extensions.Configuration;

using DevFreela.Domain.Dtos;
using DevFreela.Domain.Services;
using DevFreela.Infrastructure.MessageBus;

namespace DevFreela.Infrastructure.Payment;

public class PaymentService : IPaymentService
{
    private readonly IMessageBusService _messageBusService;
    private readonly string _queue;

    public PaymentService(IMessageBusService messageBusService, IConfiguration configuration)
    {
        _messageBusService = messageBusService;
        _queue = configuration.GetSection("Services:RabbitMq:Queue").Value;

        if (string.IsNullOrWhiteSpace(_queue))
            throw new ArgumentNullException($"The queue name of {nameof(_queue)} cannot be null or empty");
    }

    public void ProcessPayment(PaymentInfoDto paymentInfoDto)
    {
        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);
        var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

        _messageBusService.Publish(_queue, paymentInfoBytes);
    }
}