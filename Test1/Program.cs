using Test1.Core;

namespace Test1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string logPath = "log.txt";
            Logger logger = new Logger(logPath);
            ICommandExecutor ce = new RetryingCommandExecutor(logger);
            var bl = new BusinessLogicManager(ce);
            bl.DoSomeBusinessLogic();
            Console.Read();
        }
    }
}
