using BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder.Users;

namespace BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder;

public class GetUsersResponse
{
    public IEnumerable<UserDto>? Users { get; set; }
}
