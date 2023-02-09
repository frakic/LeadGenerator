using BitMouse.LeadGenerator.Infrastructure.Domain;

namespace BitMouse.LeadGenerator.Model.Users;

public class ContactDetails : Entity
{
    public string Email { get; private set; } = default!;
    public string? Phone { get; internal set; }
    public string? Website { get; internal set; }

    private ContactDetails()
    {
    }

    internal ContactDetails(string email)
    {
        Email = email;
    }
}