namespace BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder;

public interface IJsonPlaceholderService
{
    Task<GetUsersResponse> GetUsersAsync(GetUsersRequest request);
}
