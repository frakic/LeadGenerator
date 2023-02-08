using BitMouse.LeadGenerator.Infrastructure.Domain;

namespace BitMouse.LeadGenerator.Model.Companies;

public class Company : Entity
{
    public string? Name { get; private set; }
    public string? CatchPhrase { get; private set; }
    public string? BusinessStrategy { get; private set; }
}
