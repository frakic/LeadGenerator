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
    private readonly IUserQuery _userQuery;

    public UserService(IntegrationApiSettings integrationApiSettings,
        HttpClient httpClient,
        IUserRepository userRepository,
        UserManager userManager,
        IUserQuery userQuery)
    {
        _integrationApiSettings = integrationApiSettings;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(_integrationApiSettings.BaseUrl);
        _userRepository = userRepository;
        _userManager = userManager;
        _userQuery = userQuery;
    }

    public async Task<IEnumerable<BusinessUserDto>> GetBusinessUsersAsync()
    {
        return await _userQuery.GetBusinessUsersAsync();
    }

    public async Task SaveUserAsync(UserRequestDto request)
    {
        var user = await _userManager
            .CreateBasicAsync(request.FirstName, request.LastName, request.Email);

        var integrationRequestUrl = ResolveIntegrationUrl(request);

        var integrationResponse = await _httpClient.GetAsync(integrationRequestUrl);

        if (integrationResponse.StatusCode == HttpStatusCode.OK)
        {
            var userIntegrationData = await integrationResponse.Content.ReadFromJsonAsync<UserIntegrationDataDto>();

            _userManager.FillWithIntegrationData(user, userIntegrationData!);
        }

        await _userRepository.InsertAsync(user);
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
