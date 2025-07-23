using System.Text.Json.Serialization;

namespace BoxSellerWebApp.Entity
{
    public class GeoLocalizacao
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }
}
