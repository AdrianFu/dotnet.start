namespace Core.Kafka;

public interface IEventProducer
{
    Task Produce(string topic, string key, string value, CancellationToken cancellationToken);
}
