namespace BitMouse.LeadGenerator.Contract.Users;

public interface IUserService
{
    Task SaveUserAsync(UserRequestDto request);
}
