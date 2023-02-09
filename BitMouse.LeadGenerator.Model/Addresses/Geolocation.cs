using BitMouse.LeadGenerator.Infrastructure.Domain;

namespace BitMouse.LeadGenerator.Model.Addresses;

public class Geolocation : Entity
{
    public string? Latitude { get; internal set; }
    public string? Longitude { get; internal set; }

    internal Geolocation()
    {
    }
}
