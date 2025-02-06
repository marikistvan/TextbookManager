using Textbook.Data;
using TextbookManager.Business.Interfaces;
using TextbookManager.Data;
using TextbookManager.Domain.Model;
namespace TextbookManager.Business
{
    public class TextbookService : ITextbookService
    {
        private MergeModelClasses _mergeClasses;
        private DataManager _dataManager;

        public TextbookService() { 
            _dataManager = new DataManager();
            _mergeClasses = _dataManager.GetAll();
        }

        public void Create(TextBook textbook)
        {
            _mergeClasses.Textbooks.Add(textbook);
        }

        public void Delete(int id)
        {
            TextBook? textbook = Get(id);
            if(textbook != null)
            {
                _mergeClasses.Textbooks.Remove(textbook);
            }
        }

        public List<TextBook>? Get()
        {
            return _mergeClasses.Textbooks;
        }

        public TextBook? Get(int id)
        {
            return _mergeClasses.Textbooks.Find(x => x.Id == id);
        }

        public TextBook? Get(string name)
        {
            return _mergeClasses.Textbooks.Find(x => x.Name == name);
        }
    }
}
