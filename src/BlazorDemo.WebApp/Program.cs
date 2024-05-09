using BlazorDemo.WebApp.Components;
using BlazorDemo.WebApp.Extensions;
using BlazorDemo.WebApp.Providers;
using BlazorDemo.WebApp.Services.Implementations;
using BlazorDemo.WebApp.Services.Interfaces;
using BlazorDemo.WebApp.Settings;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddRazorComponents().AddInteractiveServerComponents();
services.AddCascadingAuthenticationState();

services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = AppConstants.AuthenticationType;
        options.DefaultChallengeScheme = AppConstants.AuthenticationType;
    });

services.AddAuthorizationCore();

services.AddScoped<AuthenticationStateProvider, BlazorDemoAuthenticationStateProvider>();

services.AddHttpContextAccessor();

services.AddOptions<ApiSettings>()
    .Bind(builder.Configuration.GetSection(nameof(ApiSettings)));

var apiSettingsOptions = services.GetRequiredService<IOptions<ApiSettings>>();

var apiSettings = apiSettingsOptions.Value;

services.AddHttpClient<IAccountServices, AccountServices>(
    client =>
    {
        client.BaseAddress = new Uri($"{apiSettings.BaseUrl}{apiSettings.AccountsRoute}");
    });

services.AddHttpClient<IEventServices, EventServices>(
    client =>
    {
        client.BaseAddress = new Uri($"{apiSettings.BaseUrl}{apiSettings.EventsRoute}");
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();