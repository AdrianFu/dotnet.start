using Confluent.Kafka;

namespace Core.Kafka;

public class Consumer : BackgroundService
{
    private readonly ILogger _logger;
    private readonly IConfiguration _kafkaConfiguration;

    const string topic = "purchases";


    public Consumer(
        IConfiguration configuration,
        ILogger<Consumer> logger)
    {
        _logger = logger;

        var fileLoc = configuration["kafka.properties"] ?? "";
        _logger.LogInformation("Getting kafka.properties from: {fileLoc}", fileLoc);

        var groupId = configuration["kafka-consumer-gropu-id"];
        if (string.IsNullOrEmpty(groupId))
        {
            throw new Exception("Missing configuration: kafka-consumer-gropu-id");
        }

        _kafkaConfiguration = new ConfigurationBuilder()
            .AddIniFile(fileLoc)
            .Build();

        _kafkaConfiguration["group.id"] = groupId;
        _kafkaConfiguration["auto.offset.reset"] = "earliest";
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Random rnd = new Random();
        using (var consumer = new ConsumerBuilder<string, string>(
            _kafkaConfiguration.AsEnumerable()).Build())
        {
            consumer.Subscribe(topic);
            try
            {
                while (true)
                {
                    var cr = consumer.Consume(stoppingToken);
                    _logger.LogInformation("Consumed event from topic {topic} with key {key} and value {value}", topic,cr.Message.Key, cr.Message.Value);
                    await Task.Delay(1000, stoppingToken);
                }
            }
            finally
            {
                consumer.Close();
                _logger.LogInformation("Consumer closed");
            }
        }
    }
}