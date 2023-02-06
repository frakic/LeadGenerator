using BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder;
using BitMouse.LeadGenerator.Integration.Service.Settings;

namespace BitMouse.LeadGenerator.Integration.Service.HttpClients.JsonPlaceholder;

public class JsonPlaceholderHttpClient
{
    private readonly JsonPlaceholderApiSettings _jsonPlaceholderApiSettings;
    private readonly HttpClient _httpClient;

    public JsonPlaceholderHttpClient(JsonPlaceholderApiSettings jsonPlaceholderApiSettings,
        HttpClient httpClient)
    {
        _jsonPlaceholderApiSettings = jsonPlaceholderApiSettings;
        _httpClient = httpClient;
    }

    public async Task<string> GetUsersAsTextAsync(GetUsersRequest request)
    {
        var requestUrl = $"{_jsonPlaceholderApiSettings.BaseUrl}?email={request.Email}";
        var response = await _httpClient.GetAsync(requestUrl);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        //TODO: log the exception
        throw new Exception("Failed to get data from JsonPlaceholder.");
    }
}
