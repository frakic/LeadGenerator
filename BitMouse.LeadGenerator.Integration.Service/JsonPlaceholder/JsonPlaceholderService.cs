﻿using BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder;
using BitMouse.LeadGenerator.Integration.Contract.JsonPlaceholder.Users;
using BitMouse.LeadGenerator.Integration.Service.HttpClients.JsonPlaceholder;
using System.Text.Json;

namespace BitMouse.LeadGenerator.Integration.Service.JsonPlaceholder;

public class JsonPlaceholderService : IJsonPlaceholderService
{
    private readonly JsonPlaceholderHttpClient _jsonPlaceholderHttpClient;

    public JsonPlaceholderService(JsonPlaceholderHttpClient jsonPlaceholderHttpClient)
    {
        _jsonPlaceholderHttpClient = jsonPlaceholderHttpClient;
    }
    public async Task<GetUsersResponse> GetUsersAsync(GetUsersRequest request)
    {
        var textUsers = await _jsonPlaceholderHttpClient.GetUsersAsTextAsync(request);

        var users = JsonSerializer.Deserialize<IEnumerable<UserDto>>(textUsers);

        var response = new GetUsersResponse { Users = users };

        return response;
    }
}
