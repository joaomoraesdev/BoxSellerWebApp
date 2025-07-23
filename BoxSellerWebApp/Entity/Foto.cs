using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class Foto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("secure_url")]
        public string UrlSegura { get; set; }

        [JsonPropertyName("size")]
        public string Tamanho { get; set; }

        [JsonPropertyName("max_size")]
        public string TamanhoMaximo { get; set; }

        [JsonPropertyName("source")]
        public string Fonte { get; set; }
    }
}
