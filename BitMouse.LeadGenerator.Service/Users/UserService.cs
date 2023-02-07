using BitMouse.LeadGenerator.Contract.Users;
using BitMouse.LeadGenerator.Service.Settings;
using Microsoft.AspNetCore.WebUtilities;
using System.Net;
using System.Net.Http.Json;

namespace BitMouse.LeadGenerator.Service.Users;

public class UserService : IUserService
{
    private readonly IntegrationApiSettings _integrationApiSettings;
    private readonly HttpClient _httpClient;

    public UserService(IntegrationApiSettings integrationApiSettings,
        HttpClient httpClient)
    {
        _integrationApiSettings = integrationApiSettings;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_integrationApiSettings.BaseUrl);
    }
    public async Task SaveUserAsync(UserRequestDto request)
    {
        var integrationRequestUrl = ResolveIntegrationUrl(request);

        var integrationResponse = await _httpClient.GetAsync(integrationRequestUrl);

        var user = integrationResponse.StatusCode == HttpStatusCode.OK
            ? await integrationResponse.Content.ReadFromJsonAsync<UserDto>()
            : null;

        // save user to DB
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
