using BitMouse.LeadGenerator.Infrastructure.Domain;
using BitMouse.LeadGenerator.Model.Addresses;
using BitMouse.LeadGenerator.Model.Companies;

namespace BitMouse.LeadGenerator.Model.Users;

public class User : Entity, IAggregateRoot
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string? Username { get; private set; }
    public ContactDetails? ContactDetails { get; private set; }
    public int? IntegrationId { get; private set; }
    public Address? Address { get; private set; }
    public Company? Company { get; private set; }

    private User()
    {
    }
    internal User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
