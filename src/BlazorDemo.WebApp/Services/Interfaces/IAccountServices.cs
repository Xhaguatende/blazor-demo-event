// -------------------------------------------------------------------------------------
//  <copyright file="IAccountServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Services.Interfaces;

using Models.Accounts;

public interface IAccountServices
{
    Task<SignInResponse> SignInAsync(
        SignInRequest request,
        CancellationToken cancellationToken = default);

    Task SignOutAsync(CancellationToken cancellationToken = default);
}