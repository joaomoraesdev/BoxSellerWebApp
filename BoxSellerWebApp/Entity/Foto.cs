using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class Foto
    {
        [JsonPropertyName("source")]
        public string Fonte { get; set; }
    }
}
