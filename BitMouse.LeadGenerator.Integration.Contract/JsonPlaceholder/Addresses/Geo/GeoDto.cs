using System.Text.Json.Serialization;

namespace BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder.Address.Geo;

public class GeoDto
{
    [JsonPropertyName("lat")]
    public string? Lat { get; set; }

    [JsonPropertyName("lng")]
    public string? Lng { get; set; }
}
