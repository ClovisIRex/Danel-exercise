using Test1.Core;

namespace Test1;

public class RetryingCommandExecutor : ICommandExecutor
{
    private Logger _logger;
    
    public RetryingCommandExecutor(Logger logger)
    {
        _logger = logger;
    }
    public void Execute(ICommand command)
    {
        
        const int maxRetries = 3;
        int retries = 0;

        while (retries < maxRetries)
        {
            try
            {
                _logger.Log($"Attempting to execute {command.GetType()}...", ConsoleColor.Yellow);
                if (new Random().Next(0, 3) == 0)
                {
                    _logger.Log($"Execution failed, service encountered an error, retrying...",
                        ConsoleColor.Red);
                    throw new TimeoutException();

                }
                
                _logger.Log($"{command.GetType()} executed successfully!",
                    ConsoleColor.Green);
                return;
            }
            catch (TimeoutException ex)
            {
                retries++;
                Console.WriteLine($"Retry attempt [{retries}/{maxRetries}]: {ex.Message}");
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                _logger.Log($"Encountered unexpected exception: {ex.Message}",
                    ConsoleColor.Red);
                return;
            }
        }
        
        _logger.Log($"Failed to execute command after {maxRetries} retries. " +
                    $"Please view the log file ath the path: " + "\n" +
                    $"{Path.GetFullPath(_logger.getLogFilePath())}",
            ConsoleColor.Red);
    }
}