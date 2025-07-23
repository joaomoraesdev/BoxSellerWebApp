using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class Pais
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; }
    }
}
