namespace Core.Kafka;

public class Producer : BackgroundService
{
    private readonly IEventProducer _eventProducer;
    private readonly ILogger<Producer> _logger;

    const string topic = "purchases";

    string[] users = { "eabara", "jsmith", "sgarcia", "jbernard", "htanaka", "awalther" };
    string[] items = { "book", "alarm clock", "t-shirts", "gift card", "batteries" };

    public Producer(
        IEventProducer eventProducer,
        ILogger<Producer> logger)
    {
        _eventProducer = eventProducer;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Random rnd = new Random();
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker publishing message at: {time}", DateTimeOffset.Now);

            var user = users[rnd.Next(users.Length)];
            var item = items[rnd.Next(items.Length)];

            await _eventProducer.Produce(topic, user, item, stoppingToken);

            await Task.Delay(1000, stoppingToken);
        }
    }
}
