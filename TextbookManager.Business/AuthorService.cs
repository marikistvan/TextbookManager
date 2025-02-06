using Textbook.Data;
using TextbookManager.Business.Interfaces;
using TextbookManager.Data;
using TextbookManager.Data.Model;

namespace TextbookManager.Business
{
    public class AuthorService : IAuthorService
    {
        private MergeModelClasses _mergeClasses;
        private DataManager _dataManager;
        public AuthorService()
        {
            _dataManager = new DataManager();
            _mergeClasses =new DataManager().GetAll();
        }
        public void Delete(int id)
        {
            Author? author1 = _mergeClasses.Authors.Find(x => x.Id == id);
            List<TextBook> textbooks = new List<TextBook>();

            if (author1 != null)
            {
                textbooks = _mergeClasses.Textbooks.FindAll(x => x.AuthorId == author1.Id);
                if (textbooks != null)
                {
                    for (int i = 0; i < textbooks.Count; i++)
                    {
                        _mergeClasses.Textbooks.Remove(textbooks[i]);
                    }
                }
                _mergeClasses.Authors.Remove(author1);
            }
        }
        public AuthorWithHisBooks? Get(string name)
        {
            List<Author> authors = _mergeClasses.Authors.FindAll(x=>x.Name==name);
            List<TextBook> textbooks = new List<TextBook>();
            if (authors == null)
            {
                return null;
            }
            else
            {
             for(int i= 0; i < authors.Count; i++)
                {
                    textbooks =_mergeClasses.Textbooks.FindAll(x => x.AuthorId == authors[i].Id);
                }
            }
            AuthorWithHisBooks authorWithHisBooks = new AuthorWithHisBooks
            {
                Authors = new List<Author>(),
                Books = new List<TextBook>()
            };
            foreach (Author author in authors) 
            {
                authorWithHisBooks.Authors.Add(author);
            }
            foreach (TextBook item in textbooks)
            {
                authorWithHisBooks.Books.Add(item);
            }
            return authorWithHisBooks;
        }
        public AuthorWithHisBooks? Get(int id)
        {
            Author? author1 = _mergeClasses.Authors.Find(x => x.Id == id);
            List<TextBook> textbooks = new List<TextBook>();

            if (author1 != null)
            {
                textbooks = _mergeClasses.Textbooks.FindAll(x => x.AuthorId == author1.Id);
            }
            else
            {
                return null;
            }
            AuthorWithHisBooks authorWithHisBooks = new AuthorWithHisBooks
            {
                Authors = new List<Author>(),
                Books = new List<TextBook>()
            };
            authorWithHisBooks.Authors.Add(author1);
            foreach (TextBook item in textbooks)
            {
                authorWithHisBooks.Books.Add(item);
            }
            return authorWithHisBooks; 
        }

        public List<Author>? Get()
        {
            return _mergeClasses.Authors;
        }
    }
}
