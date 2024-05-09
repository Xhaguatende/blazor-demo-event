// -------------------------------------------------------------------------------------
//  <copyright file="AccountServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Services.Implementations;

using Base;
using Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models.Accounts;
using Settings;

public class AccountServices : ServiceBase, IAccountServices
{
    private readonly NavigationManager _navigation;
    private readonly ProtectedSessionStorage _sessionStorage;

    public AccountServices(HttpClient httpClient, ProtectedSessionStorage sessionStorage, NavigationManager navigation)
        : base(httpClient, sessionStorage)
    {
        _sessionStorage = sessionStorage;
        _navigation = navigation;
    }

    public async Task<SignInResponse> SignInAsync(
            SignInRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await PostAsync<SignInRequest, SignInResponse>("sign-in", request, cancellationToken);

        if (response == null)
        {
            return new SignInResponse
            {
                Message = "An error occurred during sign-in. Please, check if your email is valid."
            };
        }

        await _sessionStorage.SetAsync(AppConstants.UserSession, response);

        return response;
    }

    public async Task SignOutAsync(CancellationToken cancellationToken = default)
    {
        await _sessionStorage.DeleteAsync(AppConstants.UserSession);

        _navigation.NavigateTo("/", true);
    }
}