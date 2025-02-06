using TextbookManager.Business.Interfaces;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;
using TextbookManager.Domain.Model;

namespace TextbookManager.Business.IShellCommandLogic.Application
{
    public class GetTextbookCommand : IShellCommand
    {
        public string Name => "get-b";
        public TextBook Book { get; set; }
        private ITextbookService _service;
        public void GetService(IServiceContainer serviceContainer)
        {
            _service = serviceContainer.TextbookService;
        }
        public void WriteBook(TextBook book)
        {
            Console.WriteLine("Id :" + book.Id + " Name: " + book.Name + " Author Id: " + book.AuthorId + " Published Year: " + book.PublishedYear);
        }
        public void Execute(string[] args)
        {
            if (args.Length == 1)
            {
                List<TextBook> textBooks = _service.Get();
                if (textBooks != null)
                {
                    for (int i = 0; i < textBooks.Count; i++)
                    {
                        WriteBook(textBooks[i]);
                    }
                }
            }
            else if (args.Length >= 2 && args[1].Length > 0)
            {
                if (int.TryParse(args[1], out int number))
                {
                    Book = _service.Get(number);
                    if (Book != null)
                    {
                        WriteBook(Book);
                    }
                }
                else
                {
                    string bookName = "";
                    for (int i = 1; i < args.Length; i++)
                    {
                        bookName += args[i] + " ";
                    }
                    bookName = bookName.Trim();
                    if (bookName != null)
                    {
                        Book = _service.Get(bookName);
                        if (Book != null)
                        {
                            WriteBook(Book);
                        }
                    }
                }
            }
        }
    }
}
