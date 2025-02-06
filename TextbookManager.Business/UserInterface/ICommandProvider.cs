using TextbookManager.Business.IShellCommandLogic.Infrastructure;

namespace TextbookManager.Business.UserInterface
{
    public interface ICommandProvider
    {
        IShellCommand[] Commands { get; }
    }
}
