// -------------------------------------------------------------------------------------
//  <copyright file="SignInResponse.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Models.Accounts;

using System.Text.Json.Serialization;

public class SignInResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = default!;

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    public string Message { get; set; } = default!;

    [JsonPropertyName("refresh_token")]
    public string RefreshToken { get; set; } = default!;

    public bool Success => !string.IsNullOrWhiteSpace(AccessToken);
}