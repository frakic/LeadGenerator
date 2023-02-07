using BitMouse.LeadGenerator.Infrastructure.Domain;

namespace BitMouse.LeadGenerator.Model.Addresses;

public class Geolocation : Entity
{
    public string? Latitude { get; private set; }
    public string? Longitude { get; private set; }
}
