using BitMouse.LeadGenerator.Infrastructure.Domain;
using BitMouse.LeadGenerator.Model.Addresses;
using BitMouse.LeadGenerator.Model.Companies;

namespace BitMouse.LeadGenerator.Model.Users;

public class User : Entity, IAggregateRoot
{
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string? Username { get; internal set; }
    public ContactDetails ContactDetails { get; internal set; } = default!;
    public int? IntegrationId { get; internal set; }
    public Address? Address { get; internal set; }
    public Company? Company { get; internal set; }

    internal User()
    {
    }

    internal User(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        ContactDetails = new ContactDetails(email);
    }
}
