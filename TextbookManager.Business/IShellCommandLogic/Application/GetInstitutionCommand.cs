using TextbookManager.Business.Interfaces;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;
using TextbookManager.Data.Model;

namespace TextbookManager.Business.IShellCommandLogic.Application
{
    public class GetInstitutionCommand : IShellCommand
    {
        public string Name => "get-i";
        public InstitutionWithHisBooks InstitutionWithHisBooks { get; set; }
        private IInstitutionService _service;
        public void GetService(IServiceContainer serviceContainer)
        {
            _service = serviceContainer.InstitutionService;
        }
        public void Execute(string[] args)
        {
            if (args.Length >= 2 && args[1].Length > 0)
            {
                string institutionName = "";
                for (int i = 1; i < args.Length; i++)
                {
                    institutionName += args[i] + " ";
                }
                institutionName = institutionName.Trim();
                if (institutionName != null)
                {
                    InstitutionWithHisBooks = _service.Get(institutionName);
                    if (InstitutionWithHisBooks != null)
                    {
                        Console.WriteLine("Id :" + InstitutionWithHisBooks.Institution.Id + " Name: " + InstitutionWithHisBooks.Institution.Name);
                        if (InstitutionWithHisBooks.Books != null)
                        {
                            for (int i = 0; i < InstitutionWithHisBooks.Books.Count; i++)
                            {
                                Console.WriteLine("Id :" + InstitutionWithHisBooks.Books[i].Id + " Name: " + InstitutionWithHisBooks.Books[i].Name
                                + " Author Id: " + InstitutionWithHisBooks.Books[i].AuthorId + " Published Year: " + InstitutionWithHisBooks.Books[i].PublishedYear);

                            }
                        }
                    }
                }
            }
        }
    }
}
