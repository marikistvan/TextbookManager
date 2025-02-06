using TextbookManager.Data.Model;

namespace TextbookManager.Data.Model
{
    public   class InstitutionWithHisBooks
    {
        public Institution Institution { get; set; }
        public List<TextBook> Books { get; set; }
    }
}
