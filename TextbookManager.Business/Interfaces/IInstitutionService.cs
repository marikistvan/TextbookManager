using TextbookManager.Domain.Model;
using TextbookManager.Domain.Models;

namespace TextbookManager.Business.Interfaces
{
    public interface IInstitutionService
    {
        List<Institution> Get();
        InstitutionWithHisBooks? Get(string name);
        InstitutionWithHisBooks? Get(int id);
        void Add(int textbookId, int institution);
    }
}
