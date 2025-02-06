using System.Text.Json.Serialization;

namespace TextbookManager.Data.Model
{
    public class TextBook
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Nev")]
        public string Name { get; set; }

        [JsonPropertyName("Szerzo")]
        public int AuthorId { get; set; }

        [JsonPropertyName("Kiadasi_ev")]
        public int PublishedYear { get; set; }
    }
}
