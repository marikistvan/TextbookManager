using System.Reflection;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;

namespace TextbookManager.Business.UserInterface
{
    public class ReflectionCommandLoader :ICommandProvider
    {
        public IShellCommand[] Commands { get; }

        public ReflectionCommandLoader()
        {
            Commands = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => typeof(IShellCommand).IsAssignableFrom(type)
                               && !type.IsAbstract
                               && !type.IsInterface)
                .Select(type => Activator.CreateInstance(type) as IShellCommand)
                .Where(command => command != null)
                .ToArray()!;
        }
    }
}
