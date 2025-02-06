using TextbookManager.Business.Interfaces;

namespace TextbookManager.Business
{
    public class ServiceContainer : IServiceContainer
    {
        public ITextbookService TextbookService { get; }
        public IAuthorService AuthorService { get; }
        public IInstitutionService InstitutionService { get; }

        public ServiceContainer()
        {
            TextbookService = new TextbookService();
            AuthorService = new AuthorService();
            InstitutionService = new InstitutionService();
        }
    }
}
