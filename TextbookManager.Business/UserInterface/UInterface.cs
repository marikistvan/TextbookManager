using TextbookManager.Business.Interfaces;
using System.Diagnostics;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;

namespace TextbookManager.Business.UserInterface
{
    public class UInterface
    {
        private ICommandProvider _commandProvider;
        private string? _input;
        private IServiceContainer _service;

        public UInterface(ICommandProvider commandProvider,IServiceContainer serviceContainer)
        {
            _commandProvider = commandProvider;
            _service = serviceContainer;
        }
        public void Run()
        {
            while (true)
            {
                Console.Write("> ");
                _input = Console.ReadLine() ?? throw new InvalidOperationException();
                string[] splittedInput = _input.Split(' ');
                IShellCommand? commandToExecute = FindCommandName(splittedInput[0]);
                if (commandToExecute != null)
                {
                    try
                    {
                        commandToExecute.GetService(_service);
                        commandToExecute.Execute(splittedInput);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred "+ex);
                        Trace.WriteLine(ex, "commandexception");
                    }
                }
            }
        }
        private IShellCommand? FindCommandName(string commandName)
        {
            foreach (var command in _commandProvider.Commands)
            {
                if (command.Name.Equals(commandName, StringComparison.CurrentCultureIgnoreCase))
                {
                    return command;
                }
            }
            return null;
        }
    }
}
