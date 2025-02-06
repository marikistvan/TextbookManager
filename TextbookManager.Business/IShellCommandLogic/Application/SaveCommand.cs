using TextbookManager.Business.Interfaces;
using TextbookManager.Data;
using TextbookManager.Data.Model;
using TextbookManager.Business.IShellCommandLogic.Infrastructure;
namespace TextbookManager.Business.IShellCommandLogic.Application
{
    internal class SaveCommand : IShellCommand
    {
        public string Name => "save";
        public MergeModelClasses MergeModelClasses;
        private ITextbookService _textbookService;
        private IAuthorService _authorService;
        private IInstitutionService _institutionService;
        private bool _isSucces = false;

        public void Execute(string[] args)
        {
            MergeModelClasses = new MergeModelClasses();
            MergeModelClasses.Textbooks = new List<TextBook>();
            MergeModelClasses.Institutions = new List<Institution>();
            MergeModelClasses.Authors = new List<Author>();
            List<TextBook> textBooks = _textbookService.Get();
            List<Author> authors = _authorService.Get();
            List<Institution> institution = _institutionService.Get();
            if (textBooks != null)
            {
                for (int i = 0; i < textBooks.Count; i++)
                {

                    MergeModelClasses.Textbooks.Add(textBooks[i]);
                }
            }
            if(authors != null)
            {
                for (int i = 0; i < authors.Count; i++)
                {
                    MergeModelClasses.Authors.Add(authors[i]);
                }
            }
            if(institution != null)
            {
                for (int i = 0; i < institution.Count; i++)
                {
                    MergeModelClasses.Institutions.Add(institution[i]);
                }
            }
            _isSucces = DBManager.UpdateDB(MergeModelClasses);
            if (_isSucces) {
                Console.WriteLine("Save successful");
            }
            else
            {
                Console.WriteLine("An error occurred during saving");
            }
        }

        public void GetService(IServiceContainer serviceContainer)
        {
            _textbookService = serviceContainer.TextbookService;
            _authorService = serviceContainer.AuthorService;
            _institutionService = serviceContainer.InstitutionService;
        }
    }
}
