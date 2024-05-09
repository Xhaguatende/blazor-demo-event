// -------------------------------------------------------------------------------------
//  <copyright file="IEventServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Services.Interfaces;

using Models.Events;

public interface IEventServices
{
    Task<List<EventRow>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<GetEvent?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpsertEvent> UpsertAsync(UpsertEvent upsertEvent, CancellationToken cancellationToken = default);
}