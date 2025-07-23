using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class Estado
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; }
    }
}
