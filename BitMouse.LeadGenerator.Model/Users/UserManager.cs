using BitMouse.LeadGenerator.Infrastructure.Domain;

namespace BitMouse.LeadGenerator.Model.Users;

public class UserManager
{
    //private readonly IUserBuilder _userBuilder;
    private readonly IUserRepository _userRepositry;

    public UserManager(
        //IUserBuilder userBuilder, 
        IUserRepository userRepositry)
    {
        //_userBuilder = userBuilder;
        _userRepositry = userRepositry;
    }

    public async Task<User> CreateAsync(string firstName, string lastName, string email)
    {
        var lastSaved = await _userRepositry.GetDateCreatedByEmail(email);
        
        //TODO: resolve UTC time difference
        if (DateTime.UtcNow.AddMinutes(-1) < lastSaved)
        {
            throw new BusinessException(
                "Adding duplicate user records within 1 minute is not permitted",
                "User.DuplicateNotPermitted",
                (DateTime)lastSaved);
        }

        return new User();
    }
}
