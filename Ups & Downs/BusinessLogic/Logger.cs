using Serilog;

namespace UpsAndDowns.BusinessLogic;

public static class Logger
{
    private static Serilog.Core.Logger _logger = new LoggerConfiguration()
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

    static Logger()
    {
        _logger = new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    public static void Log(string message, object? context = null)
    {
        if (context is null)
        {
            Console.WriteLine($"{DateTime.Now} :: {message}");
            _logger.Information(message);
            return;
        }
        else
        {
            Console.WriteLine($"{DateTime.Now} :: {message} :: {context}");
            _logger.Information("{Message}, {Context}", message, context);
        }
    }
}
