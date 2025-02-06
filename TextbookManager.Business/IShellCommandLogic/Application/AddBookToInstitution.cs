using TextbookManager.Business.Interfaces;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;
using TextbookManager.Domain.Model;
using TextbookManager.Domain.Models;

namespace TextbookManager.Business.IShellCommandLogic.Application
{
    internal class AddBookToInstitution : IShellCommand
    {
        private ITextbookService _textbookService;
        private IInstitutionService _service;
        public string Name => "add-b";
        public TextBook Book { get; set; }
        public InstitutionWithHisBooks InstitutionWithHisBooks { get; set; }


        public void Execute(string[] args)
        {
            if (args.Length == 3)
            {
                if (args[1].Length > 0 && args[2].Length > 0)
                {
                    if (int.TryParse(args[1], out int textbookNumber))
                    {
                        Book = _textbookService.Get(textbookNumber);
                        if (Book == null)
                        {
                            return;
                        }
                    }
                    if (int.TryParse(args[2], out int institutionNumber))
                    {
                        InstitutionWithHisBooks = _service.Get(institutionNumber);
                        if (InstitutionWithHisBooks == null)
                        {
                            return;
                        }
                    }
                    _service.Add(Book.Id, InstitutionWithHisBooks.Institution.Id);
                }
            }

        }

        public void GetService(IServiceContainer serviceContainer)
        {
            _service = serviceContainer.InstitutionService;
            _textbookService = serviceContainer.TextbookService;
        }
    }
}
