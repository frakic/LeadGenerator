using BitMouse.LeadGenerator.Model.Addresses;
using BitMouse.LeadGenerator.Model.Companies;

namespace BitMouse.LeadGenerator.Model.Users;

public class UserBuilder : IUserBuilder
{
    private readonly User _user = default!;

    public UserBuilder()
    {

    }

    internal UserBuilder(string firstName, string lastName, string email)
    {
        _user = new User(firstName, lastName, email);
    }

    public UserBuilder WithContactDetails(string? phone, string? website)
    {
        _user.ContactDetails.Phone = phone;
        _user.ContactDetails.Website = website;

        return this;
    }

    public UserBuilder WithAddress(string? street, string? suite, string? city, string? zipcode)
    {
        _user.Address ??= new Address();

        _user.Address.Street = street;
        _user.Address.Suite = suite;
        _user.Address.City = city;
        _user.Address.ZipCode = zipcode;

        return this;
    }

    public UserBuilder WithGeolocation(string? latitude, string? longitude)
    {
        _user.Address ??= new Address();

        _user.Address.Geolocation = new Geolocation
        {
            Latitude = latitude,
            Longitude = longitude
        };

        return this;
    }

    public UserBuilder WithCompany(string? name, string? catchPhrase, string? businessStrategy)
    {
        _user.Company = new Company
        {
            Name = name,
            CatchPhrase = catchPhrase,
            BusinessStrategy = businessStrategy
        };
        return this;
    }

    public UserBuilder WithIntegrationData(int? integrationId, string? username)
    {
        _user.IntegrationId = integrationId;
        _user.Username = username;

        return this;
    }

    public User Build()
    {
        return _user;
    }
}
