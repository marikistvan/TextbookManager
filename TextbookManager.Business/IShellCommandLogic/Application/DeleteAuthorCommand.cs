using TextbookManager.Business.Interfaces;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;
using TextbookManager.Domain.Model;

namespace TextbookManager.Business.IShellCommandLogic.Application
{
    internal class DeleteAuthorCommand : IShellCommand
    {
        public string Name => "delete-a";
        IAuthorService _service;
        ITextbookService _textbookService;

        public void GetService(IServiceContainer serviceContainer)
        {
            _service = serviceContainer.AuthorService;
            _textbookService = serviceContainer.TextbookService;
        }

        public void Execute(string[] args)
        {
            if (args.Length >= 2 && args[1].Length > 0)
            {
                if (int.TryParse(args[1], out int number))
                {
                    List<TextBook> textBooks = _textbookService.Get();
                    if (textBooks != null)
                    {
                        for (int i = 0; i < textBooks.Count; i++)
                        {
                            if (textBooks[i].AuthorId == number)
                            {
                                _textbookService.Delete(textBooks[i].Id);
                            }
                        }
                    }
                    _service.Delete(number);
                }
            }
        }
    }
}
