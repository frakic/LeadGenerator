using BitMouse.LeadGenerator.Contract.Users;
using BitMouse.LeadGenerator.Model.Users;
using BitMouse.LeadGenerator.Service.Settings;
using System.Net;
using System.Net.Http.Json;

namespace BitMouse.LeadGenerator.Service.Users;

public class UserService : IUserService
{
    private readonly IntegrationApiSettings _integrationApiSettings;
    private readonly HttpClient _httpClient;
    //TODO: remove and use domain service instead
    private readonly IUserRepository _userRepository;

    public UserService(IntegrationApiSettings integrationApiSettings,
        HttpClient httpClient,
        IUserRepository userRepository)
    {
        _integrationApiSettings = integrationApiSettings;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_integrationApiSettings.BaseUrl);
        _userRepository = userRepository;
    }
    public async Task SaveUserAsync(UserRequestDto request)
    {
        var integrationRequestUrl = ResolveIntegrationUrl(request);

        var integrationResponse = await _httpClient.GetAsync(integrationRequestUrl);

        var user = integrationResponse.StatusCode == HttpStatusCode.OK
            ? await integrationResponse.Content.ReadFromJsonAsync<UserDto>()
            : null;

        var test = new User(request.FirstName, request.LastName, request.Email);

        await _userRepository.InsertAsync(test);
    }

    private string ResolveIntegrationUrl(UserRequestDto request)
    {
        var firstName = request.FirstName.Replace(" ", "+");
        var lastName = request.LastName.Replace(" ", "+");
        var url =
            $"{_integrationApiSettings.Users}?firstName={firstName}&lastName={lastName}&email={request.Email}";

        return url;
    }
}
