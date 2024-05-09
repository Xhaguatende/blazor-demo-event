// -------------------------------------------------------------------------------------
//  <copyright file="ServiceBase.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Services.Implementations.Base;

using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models.Accounts;
using Settings;

public abstract class ServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly ProtectedSessionStorage _sessionStorage;

    protected ServiceBase(HttpClient httpClient, ProtectedSessionStorage sessionStorage)
    {
        _httpClient = httpClient;
        _sessionStorage = sessionStorage;
    }

    protected async Task DeleteAsync(string uri, CancellationToken cancellationToken = default)
    {
        await SetAuthorizationHeaderAsync();

        await _httpClient.DeleteAsync(uri, cancellationToken);
    }

    protected async Task<T?> GetAsync<T>(string uri, CancellationToken cancellationToken = default)
    {
        await SetAuthorizationHeaderAsync();

        var response = await _httpClient.GetFromJsonAsync<T>(uri, cancellationToken);

        return response;
    }

    protected async Task PostAsync<T>(string uri, T data, CancellationToken cancellationToken = default)
    {
        await SetAuthorizationHeaderAsync();

        await _httpClient.PostAsJsonAsync(uri, data, cancellationToken);
    }

    protected async Task<TValue?> PostAsync<T, TValue>(string uri, T data, CancellationToken cancellationToken = default)
    {
        await SetAuthorizationHeaderAsync();

        var response = await _httpClient.PostAsJsonAsync(uri, data, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        var result = await response.Content.ReadFromJsonAsync<TValue>(cancellationToken: cancellationToken);

        return result!;
    }

    private async Task<string> GetAccessTokenAsync()
    {
        var signInResponse = await GetSessionValueAsync<SignInResponse>(AppConstants.UserSession);

        return signInResponse?.AccessToken ?? string.Empty;
    }

    private async Task<T?> GetSessionValueAsync<T>(string key)
    {
        var result = await _sessionStorage.GetAsync<T>(key);

        if (!result.Success)
        {
            return default;
        }

        var value = result.Value;

        return value;
    }

    private async Task SetAuthorizationHeaderAsync()
    {
        var accessToken = await GetAccessTokenAsync();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }
}