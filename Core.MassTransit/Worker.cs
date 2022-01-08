using MassTransit;

namespace Core.MassTransit;

public class Worker : BackgroundService
{
    readonly IBus _bus;
    private readonly ILogger<Worker> _logger;

    public Worker(
        IBus bus,
        ILogger<Worker> logger)
    {
        _logger = logger;
        _bus = bus;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker publishing message at: {time}", DateTimeOffset.Now);

            await _bus.Publish<Message>(new {Text = $"The time is {DateTimeOffset.Now}"});

            await Task.Delay(1000, stoppingToken);
        }
    }
}
