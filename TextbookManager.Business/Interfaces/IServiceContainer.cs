namespace TextbookManager.Business.Interfaces
{
    public interface IServiceContainer
    {
        ITextbookService TextbookService { get; }
        IAuthorService AuthorService { get; }
        IInstitutionService InstitutionService { get; }
    }
}
