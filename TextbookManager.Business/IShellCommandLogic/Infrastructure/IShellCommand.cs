using TextbookManager.Business.Interfaces;

namespace TextbookManager.Business.IShellCommandLogic.Infrastructure
{
    public interface IShellCommand
    {
        string Name { get; }
        void Execute(string[] args);
        void GetService(IServiceContainer serviceContainer);
    }
}
