using BitMouse.LeadGenerator.Contract.Addresses;
using BitMouse.LeadGenerator.Contract.Companies;

namespace BitMouse.LeadGenerator.Contract.Users;

public class UserDto
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public AddressDto? Address { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public CompanyDto? Company { get; set; }
}