using TextbookManager.Data.Model;

namespace TextbookManager.Business.Interfaces
{
    public interface ITextbookService
    {
        TextBook? Get(int id);
        TextBook? Get(string name);
        List<TextBook>? Get();
        void Create(TextBook textbook);
        void Delete(int id);
    }
}
