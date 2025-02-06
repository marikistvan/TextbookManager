using TextbookManager.Domain.Model;

namespace TextbookManager.Domain.Models
{
    public   class InstitutionWithHisBooks
    {
        public Institution Institution { get; set; }
        public List<TextBook> Books { get; set; }
    }
}
