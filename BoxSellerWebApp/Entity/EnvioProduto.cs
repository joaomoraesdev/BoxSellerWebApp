using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class EnvioProduto
    {
        [JsonPropertyName("mode")]
        public string Modo { get; set; }

        [JsonPropertyName("local_pick_up")]
        public bool RetiradaLocal { get; set; }

        [JsonPropertyName("free_shipping")]
        public bool FreteGratis { get; set; }

        [JsonPropertyName("logistic_type")]
        public string TipoLogistica { get; set; }

        [JsonPropertyName("store_pick_up")]
        public bool RetiradaNaLoja { get; set; }
    }
}
