using System;
using System.Collections.Generic;

public enum LogLevel
{
    Normal,
    Warning,
    Error
}

public class LogEvent
{
    public DateTime Timestamp { get; }
    public LogLevel Level { get; }
    public string Message { get; }

    public LogEvent(LogLevel level, string message)
    {
        Timestamp = DateTime.Now;
        Level = level;
        Message = message;
    }

    public override string ToString()
    {
        return $"{Timestamp} [{Level}] {Message}";
    }
}

public class Logger
{
    private static Logger instance;
    private List<LogEvent> logEvents;

    private Logger()
    {
        logEvents = new List<LogEvent>();
    }

    public static Logger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
    }

    public void Log(LogLevel level, string message)
    {
        LogEvent logEvent = new LogEvent(level, message);
        logEvents.Add(logEvent);


        if (logEvents.Count > 10)
        {
            logEvents.RemoveAt(0);
        }
    }

    public void PrintLog()
    {
        Console.WriteLine("Последнии 10 событий:");
        foreach (var logEvent in logEvents)
        {
            Console.WriteLine(logEvent);
        }
    }
}

class Program
{
    static void Main()
    {
        Logger.Instance.Log(LogLevel.Normal, "Обычное сообщение");
        Logger.Instance.Log(LogLevel.Warning, "Сообщение-предупреждение");
        Logger.Instance.Log(LogLevel.Error, "Сообщение-ошибка");
        Logger.Instance.Log(LogLevel.Error, "Сообщение-ошибка");
        Logger.Instance.Log(LogLevel.Error, "Сообщение-ошибка");
        Logger.Instance.Log(LogLevel.Error, "Сообщение-ошибка");
        Logger.Instance.Log(LogLevel.Error, "Сообщение-ошибка");
        Logger.Instance.Log(LogLevel.Error, "Сообщение-ошибка");
        Logger.Instance.Log(LogLevel.Error, "Сообщение-ошибка");
        Logger.Instance.Log(LogLevel.Error, "Сообщение-ошибка");

        Logger.Instance.PrintLog();
    }
}
