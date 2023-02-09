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
    private readonly UserManager _userManager;
    private readonly IUserRepository _userRepository;

    public UserService(IntegrationApiSettings integrationApiSettings,
        HttpClient httpClient,
        IUserRepository userRepository,
        UserManager userManager)
    {
        _integrationApiSettings = integrationApiSettings;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_integrationApiSettings.BaseUrl);
        _userRepository = userRepository;
        _userManager = userManager;
    }
    public async Task SaveUserAsync(UserRequestDto request)
    {
        //TODO: check if user has been saved in the past minute and return before calling the integration

        await _userManager.CreateAsync(request.FirstName, request.LastName, request.Email);

        var integrationRequestUrl = ResolveIntegrationUrl(request);

        var integrationResponse = await _httpClient.GetAsync(integrationRequestUrl);

        var integrationUser = integrationResponse.StatusCode == HttpStatusCode.OK
            ? await integrationResponse.Content.ReadFromJsonAsync<UserDto>()
            : null;

        //build user model
        
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
