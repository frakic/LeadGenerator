using BitMouse.LeadGenerator.Contract.Users;
using BitMouse.LeadGenerator.Infrastructure.Domain;

namespace BitMouse.LeadGenerator.Model.Users;

public class UserManager
{
    private readonly IUserBuilder _userBuilder;
    private readonly IUserRepository _userRepositry;

    public UserManager(
        IUserBuilder userBuilder,
        IUserRepository userRepositry)
    {
        _userBuilder = userBuilder;
        _userRepositry = userRepositry;
    }

    public async Task<User> CreateBasicAsync(string firstName, string lastName, string email)
    {
        var lastSaved = await _userRepositry.GetDateCreatedByEmail(email);
        
        if (DateTime.UtcNow.AddMinutes(-1) < lastSaved)
        {
            throw new BusinessException(
                "Adding duplicate user records within 1 minute is not permitted",
                "User.DuplicateNotPermitted",
                (DateTime)lastSaved);
        }

        var basicUser = _userBuilder
            .WithBasicInfo(firstName, lastName, email)
            .Build();

        return basicUser;
    }

    public User FillWithIntegrationData(User basicUser, UserIntegrationDataDto integrationData)
    {
        basicUser = _userBuilder
            .WithBasicUser(basicUser)
            .WithContactDetails(
                integrationData.Phone,
                integrationData.Website)
            .WithAddress(
                integrationData.Address?.Street,
                integrationData.Address?.Suite,
                integrationData.Address?.City,
                integrationData.Address?.Zipcode)
            .WithGeolocation(
                integrationData.Address?.Geo?.Lat,
                integrationData.Address?.Geo?.Lng)
            .WithCompany(
                integrationData.Company?.Name,
                integrationData.Company?.CatchPhrase,
                integrationData.Company?.Bs)
            .WithIntegrationData(
                integrationData.Id,
                integrationData.Username)
            .Build();

        return basicUser;
    }
}
