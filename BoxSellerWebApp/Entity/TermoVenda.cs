﻿using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class TermoVenda
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Nome { get; set; }

        [JsonPropertyName("value_id")]
        public string IdValor { get; set; }

        [JsonPropertyName("value_name")]
        public string NomeValor { get; set; }
    }
}
