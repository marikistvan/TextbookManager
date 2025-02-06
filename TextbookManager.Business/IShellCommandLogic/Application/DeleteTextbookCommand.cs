using TextbookManager.Business.Interfaces;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;

namespace TextbookManager.Business.IShellCommandLogic.Application
{
    internal class DeleteTextbookCommand : IShellCommand
    {
        public string Name => "delete-b";
        ITextbookService _service;

        public void GetService(IServiceContainer serviceContainer)
        {
            _service = serviceContainer.TextbookService;
        }

        public void Execute(string[] args)
        {
            if (args.Length >= 2 && args[1].Length > 0)
            {
                if (int.TryParse(args[1], out int number))
                {
                    _service.Delete(number);
                }
            }
        }
    }
}
