using App.WindowsService;
namespace BackgroundServiceDemo;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly JokeService _jokeService;

    public Worker(ILogger<Worker> logger, JokeService jokeService)
    {
        _logger = logger;
        _jokeService = jokeService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                string joke = _jokeService.GetJoke();
                _logger.LogWarning("{Joke}", joke);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);
            Environment.Exit(1);
        }


    }
}
