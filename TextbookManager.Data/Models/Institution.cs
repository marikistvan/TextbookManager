using System.Text.Json.Serialization;

namespace TextbookManager.Data.Model
{
    public class Institution
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Nev")]
        public string Name { get; set; }

        [JsonPropertyName("Konyvek")]
        public List<int> KonyvekId { get; set; }

    }
}
