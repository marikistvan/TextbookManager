using System.Text.Json.Serialization;

namespace TextbookManager.Domain.Model
{
    public class Author
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Nev")]
        public string Name { get; set; }

        [JsonPropertyName("Kor")]
        public int Age { get; set; }
    }
}
