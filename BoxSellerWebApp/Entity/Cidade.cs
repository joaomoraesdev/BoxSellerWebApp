using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class Cidade
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; }
    }
}
