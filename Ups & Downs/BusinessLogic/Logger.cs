using Serilog;

namespace UpsAndDowns.BusinessLogic;

public static class Logger
{
    public static void Log(string message, object? context = null)
    {
        if (context is null)
        {
            Console.WriteLine($"{DateTime.Now} :: {message}");
            Serilog.Log.Information(message);
            return;
        }
        else
        {
            Console.WriteLine($"{DateTime.Now} :: {message} :: {context}");
            Serilog.Log.Information("{Message}, {Context}", message, context);
        }
    }
}
