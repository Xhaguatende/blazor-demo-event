// -------------------------------------------------------------------------------------
//  <copyright file="BlazorDemoAuthenticationStateProvider.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Providers;

using System.Security.Claims;
using Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models.Accounts;
using Settings;

public class BlazorDemoAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
    private readonly ProtectedSessionStorage _sessionStorage;

    public BlazorDemoAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var storageResult = await _sessionStorage.GetAsync<SignInResponse>(AppConstants.UserSession);

        if (!storageResult.Success)
        {
            return new AuthenticationState(_anonymous);
        }

        var userSession = storageResult.Value!;

        var claims = userSession.AccessToken.DecodeJwt();

        var identity = new ClaimsIdentity(claims, AppConstants.AuthenticationType);
        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

        return new AuthenticationState(user);
    }
}