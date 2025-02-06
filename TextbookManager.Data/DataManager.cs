using TextbookManager.Data;
using TextbookManager.Domain.Model;

namespace Textbook.Data
{
    public class DataManager
    {
        private MergeModelClasses _jsonDataBase;
        public DataManager()
        {
            _jsonDataBase = DBManager.ReadJsonFileToList("data.json");
        }

        public List<TextBook> GetTextbooks() { 
            return _jsonDataBase.Textbooks;
        }
        public List<Institution> GetInstitutions() {
            return _jsonDataBase.Institutions;
        }
        public List<Author> GetAuthors()
        {
            return _jsonDataBase.Authors;
        }
        public MergeModelClasses GetAll()
        {
            return _jsonDataBase;
        }
        public bool SaveData(MergeModelClasses jsonDataBase) { 
            return DBManager.UpdateDB(jsonDataBase);
        }
    }
}
