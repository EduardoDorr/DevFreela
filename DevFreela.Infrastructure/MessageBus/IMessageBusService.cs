namespace DevFreela.Infrastructure.MessageBus;

public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}