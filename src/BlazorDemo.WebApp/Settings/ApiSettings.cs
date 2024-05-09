// -------------------------------------------------------------------------------------
//  <copyright file="ApiSettings.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Settings;

public class ApiSettings
{
    public string AccountsRoute { get; set; } = default!;
    public string BaseUrl { get; set; } = default!;
    public string EventsRoute { get; set; } = default!;
}