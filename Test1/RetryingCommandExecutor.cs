using Test1.Core;

namespace Test1;

public class RetryingCommandExecutor : ICommandExecutor
{
    public void Execute(ICommand command)
    {
        
        const int maxRetries = 3;
        int retries = 0;

        while (retries < maxRetries)
        {
            try
                // Execute the action
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"Attempting to execute {command.GetType()}...");
                Console.ResetColor();

                if (new Random().Next(0, 3) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    throw new TimeoutException("Execution failed, service encountered an error, retrying...");
                    Console.ResetColor();
                }
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{command.GetType()} executed successfully!");
                Console.ResetColor();
                return;
            }
            catch (TimeoutException ex)
            {
                retries++;
                Console.WriteLine($"Retry attempt - {retries}/{maxRetries}: {ex.Message}");
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Encountered unexpected exception: {ex.Message}");
                Console.ResetColor();
                return;
            }
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Failed to execute command after {maxRetries} retries...");
        Console.ResetColor();

    }
}