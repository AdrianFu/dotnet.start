using Core.Kafka;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEventProducer, EventProducer>();
builder.Services.AddHostedService<Producer>();
builder.Services.AddHostedService<Consumer>();

var host = builder.Build();
await host.RunAsync();

