// -------------------------------------------------------------------------------------
//  <copyright file="ServiceCollectionExtensions.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorDemo.WebApp.Extensions;

public static class ServiceCollectionExtensions
{
    public static T GetRequiredService<T>(this IServiceCollection services) where T : class
    {
        var serviceProvider = services.BuildServiceProvider();

        var options = serviceProvider.GetRequiredService<T>();

        return options;
    }
}