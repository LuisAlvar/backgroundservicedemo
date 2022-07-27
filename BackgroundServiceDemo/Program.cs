using App.WindowsService;
using BackgroundServiceDemo;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

IHost host = Host.CreateDefaultBuilder(args)
    // UseWindowsService extension method configures the app to work as a Windows Service. 
    // The host service is registered for dependency injection. 
    .UseWindowsService(options => {
        options.ServiceName = ".Net Joke Service";
    })
    .ConfigureServices(services =>
    {
        LoggerProviderOptions
            .RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(services);
        services.AddSingleton<JokeService>();
        services.AddHostedService<Worker>();
    })
    .ConfigureLogging((context, logging) => {
        logging.AddConfiguration(context.Configuration.GetSection("Logging"));
    })
    .Build();

await host.RunAsync();
