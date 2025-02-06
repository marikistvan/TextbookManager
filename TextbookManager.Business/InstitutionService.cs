using Textbook.Data;
using TextbookManager.Business.Interfaces;
using TextbookManager.Data;
using TextbookManager.Domain.Model;
using TextbookManager.Domain.Models;

namespace TextbookManager.Business
{
    public class InstitutionService : IInstitutionService
    {
        private DataManager _dataManager;
        private MergeModelClasses _mergeClasses;

        public InstitutionService() { 
            _dataManager = new DataManager();
            _mergeClasses= new DataManager().GetAll();
        }

        public void Add(int textbookId, int institutionId)
        {
            TextBook? textbook = _mergeClasses.Textbooks.Find(x => x.Id == textbookId);
            Institution? institution = _mergeClasses.Institutions.Find(x => x.Id == institutionId);
            if (textbook != null && institution != null)
            {
                institution.KonyvekId.Add(textbook.Id);
            }
        }

        public InstitutionWithHisBooks? Get(string name)
        {
            Institution? institution = _mergeClasses.Institutions.Find(x => x.Name == name);
            List<TextBook> textbooks = new List<TextBook>();

            if (institution != null)
            {
                if (institution.KonyvekId.Count != 0)
                {
                    for (int i = 0; i < institution.KonyvekId.Count; i++) {
                        textbooks.Add(_mergeClasses.Textbooks.Find(x=>x.Id == institution.KonyvekId[i]));
                    }
                }
            }
            else
            {
                return null;
            }
            InstitutionWithHisBooks institutionWithHisBooks = new InstitutionWithHisBooks
            {
                Institution = institution,
                Books = new List<TextBook>()
            };
            foreach (TextBook item in textbooks)
            {
                institutionWithHisBooks.Books.Add(item);
            }
            return institutionWithHisBooks;
        }

        public InstitutionWithHisBooks? Get(int id)
        {
            Institution? institution = _mergeClasses.Institutions.Find(x => x.Id == id);
            List<TextBook> textbooks = new List<TextBook>();

            if (institution != null)
            {
                if (institution.KonyvekId.Count != 0)
                {
                    for (int i = 0; i < institution.KonyvekId.Count; i++)
                    {
                        textbooks.Add(_mergeClasses.Textbooks.Find(x => x.Id == institution.KonyvekId[i]));
                    }
                }
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
            InstitutionWithHisBooks institutionWithHisBooks = new InstitutionWithHisBooks
            {
                Institution = institution,
                Books = new List<TextBook>()
            };
            foreach (TextBook item in textbooks)
            {
                institutionWithHisBooks.Books.Add(item);
            }
            return institutionWithHisBooks;
        }

        public List<Institution> Get()
        {
            return _mergeClasses.Institutions;
        }
    }
}
