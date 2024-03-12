namespace Test1.Core
{
    public sealed class BusinessLogicManager
    {
        private readonly ICommandExecutor _commandExecuter;

        public BusinessLogicManager(ICommandExecutor commandExecuter)
        {
            _commandExecuter = commandExecuter;
        }

        public void DoSomeBusinessLogic()
        {
            _commandExecuter.Execute(new BusinessLogicCommand());
        }
    }
}