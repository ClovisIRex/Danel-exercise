using Test1.Core;

namespace Test1
{
    public class Program
    {
        static void Main(string[] args)
        {
        ICommandExecutor ce = new CommandExecutor();
        
        var bl = new BusinessLogicManager(ce);
        bl.DoSomeBusinessLogic();
        Console.Read();
        }
    }
}
