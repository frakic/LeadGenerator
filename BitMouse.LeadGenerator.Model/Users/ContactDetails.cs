using BitMouse.LeadGenerator.Infrastructure.Domain;

namespace BitMouse.LeadGenerator.Model.Users;

public class ContactDetails : Entity
{
    public string Email { get; private set; } = default!;
    public string? Phone { get; private set; }
    public string? Website { get; private set; }

    private ContactDetails()
    {
    }

    //TODO: make internal and handle in domain service
    public ContactDetails(string email)
    {
        Email = email;
    }
}