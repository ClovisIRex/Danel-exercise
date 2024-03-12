namespace Test1.Core
{
    public class CommandExecutor : ICommandExecutor
    {
        public void Execute(ICommand command)
        {
            Console.WriteLine($"Executed {command.GetType()}");

            if (new Random().Next(0, 3) == 0)
            {
                throw new TimeoutException("Service encountered an error");
            }
        }
    }
}
