using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class ProdutoMLCreateDto
    {
        [JsonPropertyName("title")]
        public string Titulo { get; set; }

        [JsonPropertyName("category_id")]
        public string IdCategoria { get; set; }

        [JsonPropertyName("price")]
        public decimal Preco { get; set; }

        [JsonPropertyName("currency_id")]
        public string IdMoeda { get; set; }

        [JsonPropertyName("available_quantity")]
        public int QtdDisponivel { get; set; }

        [JsonPropertyName("buying_mode")]
        public string ModoCompra { get; set; }  // Ex: "buy_it_now"

        [JsonPropertyName("condition")]
        public string Condicao { get; set; }  // Ex: "new"

        [JsonPropertyName("listing_type_id")]
        public string IdTipoListagem { get; set; }  // Ex: "gold_special"

        [JsonPropertyName("sale_terms")]
        public List<TermoVenda> TermoVendas { get; set; }

        [JsonPropertyName("pictures")]
        public List<Foto> Fotos { get; set; }

        [JsonPropertyName("attributes")]
        public List<AtributoProduto> Atributos { get; set; }
    }
}
