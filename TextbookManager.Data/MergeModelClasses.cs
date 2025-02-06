
using System.Text.Json.Serialization;
using TextbookManager.Domain.Model;

namespace TextbookManager.Data
{
    public class MergeModelClasses
    {
        [JsonPropertyName("Tankonyv")]
        public List<TextBook> Textbooks { get; set; }

        [JsonPropertyName("Szerzo")]
        public List<Author> Authors { get; set; }

        [JsonPropertyName("Intezmeny")]
        public List<Institution> Institutions { get; set; }
    }
}
