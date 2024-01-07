using Microsoft.Extensions.Configuration;

using RabbitMQ.Client;

using DevFreela.Domain.Services;

namespace DevFreela.Infrastructure.MessageBus;

public class MessageBusService : IMessageBusService
{
    private readonly ConnectionFactory _connectionFactory;

    public MessageBusService(IConfiguration configuration)
    {
        _connectionFactory = new ConnectionFactory
        {
            HostName = configuration.GetSection("Services:RabbitMq:HostName").Value,
            UserName = configuration.GetSection("Services:RabbitMq:UserName").Value,
            Password = configuration.GetSection("Services:RabbitMq:Password").Value
        };
    }

    public void Publish(string queue, byte[] message)
    {
        using var connection = _connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare
            (
                queue: queue,
                durable: false,
                exclusive: false,
                autoDelete: true,
                arguments: null
            );

        channel.BasicPublish
            (
                exchange: "",
                routingKey: queue,
                basicProperties: null,
                body: message
            );
    }
}