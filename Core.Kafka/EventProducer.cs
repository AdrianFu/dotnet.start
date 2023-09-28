using Confluent.Kafka;

namespace Core.Kafka;

public class EventProducer : IEventProducer, IDisposable
{
    private readonly ILogger _logger;
    private readonly IConfiguration _configuration;
    private readonly Confluent.Kafka.IProducer<string, string> _producer;

    public EventProducer(
        IConfiguration configuration,
        ILogger<EventProducer> logger)
    {
        _configuration = configuration;
        _logger = logger;

        var fileLoc = _configuration["kafka.properties"] ?? "";
        _logger.LogInformation("Getting kafka.properties from: {fileLoc}", fileLoc);

        IConfiguration kafkaConfig = new ConfigurationBuilder()
            .AddIniFile(fileLoc)
            .Build();

        _producer = new ProducerBuilder<string, string>(kafkaConfig.AsEnumerable()).Build();
    }

    public void Dispose()
    {
        _producer.Dispose();
        _logger.LogInformation("Kafka producer disposed");
    }

    async public Task Produce(string topic, string key, string value, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Producing message key: {key}", key);
        var deliveryResult = await _producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = value }, cancellationToken);
        _producer.Flush(cancellationToken);
        _logger.LogInformation("MessageKey: {key}, Topic: {topic} is delivered to Partition: {partition} Offset: {offset}", key, topic, deliveryResult.Partition, deliveryResult.Offset);
    }
}
