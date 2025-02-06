namespace TextbookManager.Domain.Model
{
    public class AuthorWithHisBooks
    {
        public List<Author> Authors { get; set; }
        public List<TextBook> Books { get; set; }
    }
}
