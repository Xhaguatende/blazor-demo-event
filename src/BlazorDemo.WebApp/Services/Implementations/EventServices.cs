// -------------------------------------------------------------------------------------
//  <copyright file="EventServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Services.Implementations;

using Base;
using Interfaces;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Models.Events;

public class EventServices : ServiceBase, IEventServices
{
    public EventServices(HttpClient httpClient, ProtectedSessionStorage sessionStorage)
        : base(httpClient, sessionStorage)
    {
    }

    public async Task<List<EventRow>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<List<EventRow>>(string.Empty, cancellationToken) ?? [];
    }

    public async Task<GetEvent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await GetAsync<GetEvent>($"{id}", cancellationToken);
    }

    public async Task<UpsertEvent> UpsertAsync(UpsertEvent upsertEvent, CancellationToken cancellationToken = default)
    {
        var response = await PostAsync<UpsertEvent, UpsertEvent>(string.Empty, upsertEvent, cancellationToken);

        return response!;
    }
}