// -------------------------------------------------------------------------------------
//  <copyright file="EventRow.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Models.Events;

public record EventRow
{
    public string CreatedBy { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public string Title { get; set; } = default!;
    public string UpdatedBy { get; set; } = default!;
}