using System.Text;
using System.Text.Json;

using Microsoft.Extensions.Configuration;

using DevFreela.Domain.Dtos;
using DevFreela.Domain.Services;

namespace DevFreela.Infrastructure.Payment;

public class PaymentService : IPaymentService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMessageBusService _messageBusService;
    private readonly string _paymentsBaseUrl;
    private readonly string _queue;

    public PaymentService(IHttpClientFactory httpClientFactory, IMessageBusService messageBusService, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _messageBusService = messageBusService;
        _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
        _queue = configuration.GetSection("Services:RabbitMq:Queue").Value;

        if (string.IsNullOrWhiteSpace(_paymentsBaseUrl))
            throw new ArgumentNullException($"The base url of {nameof(_paymentsBaseUrl)} cannot be null or empty");

        if (string.IsNullOrWhiteSpace(_queue))
            throw new ArgumentNullException($"The queue name of {nameof(_queue)} cannot be null or empty");
    }

    public async Task<bool> ProcessPaymentByApi(PaymentInfoDto paymentInfoDto)
    {
        var url = $"{_paymentsBaseUrl}/api/v1/payments";
        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);
        
        var paymentInfoContent =
            new StringContent
            (
                paymentInfoJson,
                encoding: Encoding.UTF8,
                "application/json"
            );

        var httpClient = _httpClientFactory.CreateClient("Payments");
        
        var response = await httpClient.PostAsync(url, paymentInfoContent);

        return response.IsSuccessStatusCode;
    }

    public void ProcessPayment(PaymentInfoDto paymentInfoDto)
    {
        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);
        var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);
        
        _messageBusService.Publish(_queue, paymentInfoBytes);
    }
}