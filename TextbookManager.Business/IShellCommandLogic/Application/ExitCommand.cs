using TextbookManager.Business.Interfaces;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;

namespace TextbookManager.Business.IShellCommandLogic.Application
{
    internal class ExitCommand : IShellCommand
    {
        public string Name => "stop";
        ITextbookService _service = new TextbookService();

        public void GetService(IServiceContainer serviceContainer)
        {
            _service = null;
        }

        public void Execute(string[] args)
        {
            Environment.Exit(0);
        }
    }
}
