using TextbookManager.Business.Interfaces;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;
using TextbookManager.Data.Model;

namespace TextbookManager.Business.IShellCommandLogic.Application
{
    public class GetAuthorCommand : IShellCommand

    {
        public string Name => "get-a";
        public AuthorWithHisBooks AuthorWithHisBooks { get; set; }
        private IAuthorService _service;

        public void GetService(IServiceContainer serviceContainer)
        {
            _service = serviceContainer.AuthorService;
        }

        public void Execute(string[] args)
        {
            if (args.Length == 1)
            {
                List<Author> authors = _service.Get();
                if (authors != null)
                {
                    for (int i = 0; i < authors.Count; i++)
                    {
                        Console.WriteLine("Id :" + authors[i].Id + " Name: " + authors[i].Name
                            + " Age: " + authors[i].Age);
                    }
                }
            }
            else if (args.Length >= 2 && args[1].Length > 0)
            {
                if (int.TryParse(args[1], out int number))
                {
                    AuthorWithHisBooks = _service.Get(number);
                    if (AuthorWithHisBooks != null)
                    {
                        Console.WriteLine("Id :" + AuthorWithHisBooks.Authors[0].Id + " Name: " + AuthorWithHisBooks.Authors[0].Name
                        + " Age: " + AuthorWithHisBooks.Authors[0].Age);
                        Console.WriteLine("Id :" + AuthorWithHisBooks.Books[0].Id + " Name: " + AuthorWithHisBooks.Books[0].Name
                        + " Author Id: " + AuthorWithHisBooks.Books[0].AuthorId + " Published Year: " + AuthorWithHisBooks.Books[0].PublishedYear);
                    }
                }
                else
                {
                    string authorName = "";
                    for (int i = 1; i < args.Length; i++)
                    {
                        authorName += args[i] + " ";
                    }
                    authorName = authorName.Trim();
                    if (authorName != null)
                    {
                        AuthorWithHisBooks = _service.Get(authorName);
                        if (AuthorWithHisBooks != null)
                        {
                            for (int i = 0; i < AuthorWithHisBooks.Authors.Count; i++)
                            {
                                Console.WriteLine("Id :" + AuthorWithHisBooks.Authors[i].Id + " Name: " + AuthorWithHisBooks.Authors[i].Name
                                + " Age: " + AuthorWithHisBooks.Authors[i].Age);
                                for (int j = 1; j < AuthorWithHisBooks.Books.Count; j++)
                                {
                                    Console.WriteLine("Id :" + AuthorWithHisBooks.Books[j].Id + " Name: " + AuthorWithHisBooks.Books[j].Name
                                    + " Author Id: " + AuthorWithHisBooks.Books[j].AuthorId + " Published Year: " + AuthorWithHisBooks.Books[j].PublishedYear);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
