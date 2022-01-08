using MassTransit;
using Core.MassTransit;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        /*
        * Example is ready for WebApp, not Worker
        *
        services.AddHealthChecks();

        services.Configure<HealthCheckPublisherOptions>(options =>
        {
            options.Delay = TimeSpan.FromSeconds(2);
            options.Predicate = (check) => check.Tags.Contains("ready");
        });
        */

        services.AddMassTransit(x =>
        {
            x.AddConsumer<MessageEvConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);

                /*
                cfg.ReceiveEndpoint("message-taker", e =>
                {
                    e.ConfigureConsumer<MessageEvConsumer>(context);
                });
                */
            });
        });
        services.AddMassTransitHostedService(true);

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();

