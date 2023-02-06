using BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder.Address;
using BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder.Company;
using System.Text.Json.Serialization;

namespace BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder.Users;

public class UserDto
{
    [JsonPropertyName("id")]
    public int? IntegrationId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("address")]
    public AddressDto? Address { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("company")]
    public CompanyDto? Company { get; set; }
}
