using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class AtributoProduto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("value_name")]
        public string NomeValor { get; set; }
    }
}
