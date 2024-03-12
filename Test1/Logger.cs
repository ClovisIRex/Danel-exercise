namespace Test1;

public class Logger
{

    private string _logFilePath;
    
    public Logger(string logFilePath)
    {
        _logFilePath = logFilePath;
    }
    
    public void Log(string message, ConsoleColor colour = ConsoleColor.Gray)
    {
        string logEntry = $"{DateTime.Now} - {message}";

        using (StreamWriter writer = File.AppendText(_logFilePath))
        {
            writer.WriteLine(logEntry);
        }

        Console.ForegroundColor = colour;
        Console.WriteLine(logEntry);
    }
    
    public string getLogFilePath()
    {
        return _logFilePath;
    }
}