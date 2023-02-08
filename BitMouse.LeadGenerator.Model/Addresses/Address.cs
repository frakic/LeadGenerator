using BitMouse.LeadGenerator.Infrastructure.Domain;

namespace BitMouse.LeadGenerator.Model.Addresses;

public class Address : Entity
{
    public string? Street { get; private set; }
    public string? Suite { get; private set; }
    public string? City { get; private set; }
    public string? ZipCode { get; private set; }
    public Geolocation? Geolocation { get; private set; }
}
