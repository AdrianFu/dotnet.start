using MassTransit;

namespace Core.MassTransit;

public interface Message
{
    string Text { get; }
}

public class MessageEvConsumer :
    IConsumer<Message>
{
    readonly ILogger<MessageEvConsumer> _logger;

    public MessageEvConsumer(ILogger<MessageEvConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<Message> context)
    {
        _logger.LogInformation("Received Text: {Text}", context.Message.Text);

        return Task.CompletedTask;
    }
}