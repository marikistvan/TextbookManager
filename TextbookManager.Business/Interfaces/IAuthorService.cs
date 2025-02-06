using TextbookManager.Domain.Model;

namespace TextbookManager.Business.Interfaces
{
    public interface IAuthorService
    {
        List<Author>? Get();
        AuthorWithHisBooks? Get(string name);
        AuthorWithHisBooks? Get(int id);
        void Delete(int id);

    }
}
