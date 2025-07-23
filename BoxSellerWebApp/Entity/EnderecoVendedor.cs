using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class EnderecoVendedor
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("comment")]
        public string Comentario { get; set; }

        [JsonPropertyName("address_line")]
        public string Endereco { get; set; }

        [JsonPropertyName("zip_code")]
        public string Cep { get; set; }

        [JsonPropertyName("city")]
        public Cidade Cidade { get; set; }

        [JsonPropertyName("state")]
        public Estado Estado { get; set; }

        [JsonPropertyName("country")]
        public Pais Pais { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}
