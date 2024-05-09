// -------------------------------------------------------------------------------------
//  <copyright file="GetEvent.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Models.Events;

public class GetEvent
{
    public string Description { get; set; } = default!;
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public string Title { get; set; } = default!;
}